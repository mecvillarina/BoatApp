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
            List<ERMapper> erMapper = new List<ERMapper>();
            erMapper.Add(new ERMapper() { Endpoint = "action/updateOne", ServiceName = "ConfirmDropRequest", RequestType = "ConfirmDropRequest" });
            erMapper.Add(new ERMapper() { Endpoint = "action/find", ServiceName = "GetOwnerDetails", RequestType = "OwnerRequest" });
            erMapper.Add(new ERMapper() { Endpoint = "action/find", ServiceName = "GetBoatsByOwner", RequestType = "BoatsRequest" });
            erMapper.Add(new ERMapper() { Endpoint = "action/find", ServiceName = "SubmitDropRequest", RequestType = "SubmitDropRequest" });
            erMapper.Add(new ERMapper() { Endpoint = "action/find", ServiceName = "GetAllRequests", RequestType = "GenericRequest" });
            appUIView.Mapper = erMapper;
            stk01.Add(appUIView);
        }

        
    }

}
