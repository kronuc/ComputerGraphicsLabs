using ComputerGraphicsLabs.Services.Abstracion;

namespace ComputerGraphicsLabs.ConsoleUI
{
    public class ApplicationStarter : IApplicationStarter
    {
        private readonly IVisualisationService _visualisationService;

        public ApplicationStarter(IVisualisationService visualisationService)
        {
            _visualisationService = visualisationService;
        }

        public void Start()
        {

        }

    }
}
