using System.Collections.ObjectModel;

namespace todolistCS {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();

            BindingContext = new TaskViewModel();
        }
    }

    public class TodoItem {
        public bool Done { get; set; }
        public string Title { get; set; }

        public override string ToString() {
            return Title;
        }
    }

    public class TaskViewModel : BindableObject {
        public TaskViewModel() {
            Tasks.CollectionChanged += Tasks_CollectionChanged;

            AddCommand = new Command<string>(x => Tasks.Add(new TodoItem() {Title = x}), x => !string.IsNullOrWhiteSpace(x));
            DeleteCommand = new Command<TodoItem>(x =>  Tasks.Remove(x));
        }

        private void Tasks_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
            
        }

        public Command AddCommand { get; }
        public Command DeleteCommand { get; }

        public ObservableCollection<TodoItem> Tasks { get; } = new ObservableCollection<TodoItem>();
    }
}
