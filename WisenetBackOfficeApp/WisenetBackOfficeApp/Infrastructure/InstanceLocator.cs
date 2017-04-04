namespace WisenetBackOfficeApp.Infrastructure
{
    class InstanceLocator
    {
        public InstanceLocator()
        {
            Main = new ViewModels.MainViewModel();


        }

        public ViewModels.MainViewModel Main { get; set; }
    }

    
}
