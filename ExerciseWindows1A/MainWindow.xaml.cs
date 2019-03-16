using System;
using System.Windows;

namespace ExerciseWindows1A
{
    // Anelie Decomotan
    // 2017-30211
    // March 10, 2019

    public partial class MainWindow : Window
    {
        // Label binding
        public static readonly DependencyProperty labelContentProperty =
            DependencyProperty.Register("labelContent",
            typeof(String), typeof(MainWindow), new FrameworkPropertyMetadata(string.Empty));

        public String labelContent
        {
            get { return GetValue(labelContentProperty).ToString(); }
            set { SetValue(labelContentProperty, value); }
        }

        public static readonly DependencyProperty notebookProperty =
            DependencyProperty.Register("notebook",
            typeof(String), typeof(MainWindow), new FrameworkPropertyMetadata(string.Empty));

        public String notebook
        {
            get { return GetValue(notebookProperty).ToString(); }
            set { SetValue(notebookProperty, value); }
        }

        // Properties
        static string[] notebookArray;
        static int top = 0, stackSize = 10;


        // Constructor
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            labelContent = "NOTEBOOKS";

            // Initialize stack
            notebookArray = new string[stackSize];
        }

        private void AddNotebook(object sender, RoutedEventArgs e)
        {
            addNotebook();
        }

     
        void addNotebook()
        {
            string input = notebook;

            // Push new item/notebook in the stack
            notebookArray[top] = input;
            top++;
            labelContent = "Added " + input +" notebook in stack.";
        }

        private void CheckNotebook(object sender, RoutedEventArgs e)
        {
            checkNotebook();
        }

        void checkNotebook()
        {
            if (top > 0)
            {
                // Remove/pop item/notebook on top of the stack
                top--;
                string topNotebook = notebookArray[top];
                notebookArray[top] = "";
                labelContent = topNotebook + "’s notebook is being checked.";
            }
            else
            {
                labelContent = "Notebook list is empty.";
            }
        }

        private void PeekNotebook(object sender, RoutedEventArgs e)
        {
            peekNotebook();
        }

        void peekNotebook()
        {
            if (top > 0)
            {
                // Get item on top of the stack
                string topNotebook = notebookArray[top - 1];
                labelContent = topNotebook;
            }
            else
            {
                labelContent = "Notebook list is empty.";
            }
        }

        private void CheckAllNotebook(object sender, RoutedEventArgs e)
        {
            checkAllNotebook();
        }

        void checkAllNotebook()
        {
            // Remove all the contents of the stack
            while (top > 0)
            {
                top--;
                string topNotebook = notebookArray[top];
                notebookArray[top] = "";
            }

            labelContent = "Checked all notebooks.";
        }

        private void ExitApplication(object sender, RoutedEventArgs e)
        {
            exitApplication();
        }

        void exitApplication()
        {
            Application.Current.Shutdown();
        }

    }
}
