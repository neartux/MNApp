namespace WisenetBackOfficeApp.Infrastructure
{
    class InstanceLocatorMenuDist
    {
        public InstanceLocatorMenuDist()
        {
            MenuDist = new ViewModels.MainViewModel();
        }

        public ViewModels.MainViewModel MenuDist { get; set; }
    }
}
