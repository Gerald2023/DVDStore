namespace GV.DVDCentral.UI.ViewModels
{
    public class CustomerVM
    {
        public Customer Customer { get; set; }

        public List<User> Users { get; set; } = new List<User>();   
    }
}
