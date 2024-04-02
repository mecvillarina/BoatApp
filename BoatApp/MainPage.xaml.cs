using NanoHandler;
using NanoHandler.Configs;
using BoatApp.Configs;



namespace BoatApp
{
    public partial class MainPage : ContentPage
    {
        AppUIView appUIView;

        public MainPage()
        {
            InitializeComponent();

            appUIView = new AppUIView();
            appUIView.SourceUrl = AppConstants.LocaleLoaderPage;
            appUIView.ServiceType = "BoatService";
            appUIView.Mapper.Add(new ERMapper() { Endpoint = "action/updateOne", ServiceName = "ConfirmDropRequest", RequestType = "ConfirmDropRequest" });
            appUIView.Mapper.Add(new ERMapper() { Endpoint = "action/find", ServiceName = "GetOwnerDetails", RequestType = "OwnerRequest" });
            appUIView.Mapper.Add(new ERMapper() { Endpoint = "action/find", ServiceName = "GetBoatsByOwner", RequestType = "BoatsRequest" });
            appUIView.Mapper.Add(new ERMapper() { Endpoint = "action/find", ServiceName = "SubmitDropRequest", RequestType = "SubmitDropRequest" });
            appUIView.Mapper.Add(new ERMapper() { Endpoint = "action/find", ServiceName = "GetAllRequests", RequestType = "GenericRequest" });
            stk01.Add(appUIView);
        }

        
    }

}
