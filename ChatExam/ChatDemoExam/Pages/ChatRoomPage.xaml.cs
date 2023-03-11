using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChatDemoExam.Classes;
using ChatDemoExam.DataBaseModel;
using ChatDemoExam.Pages;
using ChatDemoExam.Windows;


namespace ChatDemoExam.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChatRoomPage.xaml
    /// </summary>
    public partial class ChatRoomPage : Page
    {
        public Chatroom _chatroom;
        public ChatMessage message;
        public Employee employee;
        public EmployeeChat roomChat;
        public ChatRoomPage(Chatroom chatroom)
        {
            InitializeComponent();
            var chat= chatroom.Id_Chatroom;
            LvUser.ItemsSource = ConnectingClass.connect.EmployeeChat.Where(z => z.Chatroom_Id == chat).ToList();
            _chatroom = chatroom;
            this.DataContext = _chatroom;
            LvMessages.ItemsSource = ConnectingClass.connect.ChatMessage.Where(z => z.Chatroom_Id == chatroom.Id_Chatroom).ToList();
        }

        private void Refreshmessage()
        {
            LvMessages.ItemsSource = ConnectingClass.connect.ChatMessage.Where(z => z.Chatroom_Id == _chatroom.Id_Chatroom).ToList();
        }
        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeSearchPage(_chatroom.Id_Chatroom));
        }

        private void BtnChangeTopic_Click(object sender, RoutedEventArgs e)
        {
            ChangeTopicWindow changeTopic = new ChangeTopicWindow(_chatroom);
            changeTopic.Show(); 
        }

        private void LeaveChatroom_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtMessage.Text))
            {
                MessageBox.Show("You cannot send this message", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var message = new ChatMessage()
                {
                    Sender_Id = MainWindow.emp.Id_Employee,
                    Chatroom_Id = _chatroom.Id_Chatroom,
                    Date = DateTime.Now,
                    Message = TxtMessage.Text,
                };
                ConnectingClass.connect.ChatMessage.Add(message);
                ConnectingClass.connect.SaveChanges();
                Refreshmessage();
                TxtMessage.Text = "";
            }
          
        }
    }
}
