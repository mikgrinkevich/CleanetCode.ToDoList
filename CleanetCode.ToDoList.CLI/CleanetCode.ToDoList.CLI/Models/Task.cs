namespace CleanetCode.ToDoList.CLI.Models
{
    public class Task
    {
        //property
        private Guid Id
        {
            get
            {
                return Id;
            }
            set => Id = new Guid(); //вот тут я правильно сделал, т.к поле приватное?
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UserId { get; set; }

        //field
        //method
    } 
}

