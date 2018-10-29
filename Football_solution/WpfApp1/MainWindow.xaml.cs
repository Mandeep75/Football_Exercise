using System;
using System.Collections.Generic;
using System.Linq;
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
using BAL;
using IBAL;
using DAL;
using System.Configuration;
using IDAL;
using System.Reflection;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        FootballTeamsViewModel footballTeamsViewModel;
        public MainWindow()
        {
            InitializeComponent();

            //The concrete instations of DAL and BAL in real world scenario would be carried out by an 
            //IOC container of choce(e.g spring.NET, unity)..Theses concrete classes are instantiated here just
            //to illustrate how DI works.We are using constructor injection to illustrtae DI in this example
            MimicIOCContainer();           

            this.DataContext = footballTeamsViewModel;
        }

        private void MimicIOCContainer()
        {
            //Here we can choose which instance to instatntiate .e.g instead of FootballTeamsRepository
            //we could have chosen MockFootballTeamsRepository


            IFootballTeamsRepository footballTeamsRepository = new FootballTeamsRepository();
           // IFootballTeamsRepository footballTeamsRepository = new MockFootballTeamsRepository();

            footballTeamsRepository.DataSource = ConfigurationManager.AppSettings["FootballDBlocation"];
            IFootBallTeamService footballBl = new FootBallTeamService(footballTeamsRepository);


            footballTeamsViewModel = new FootballTeamsViewModel();

            footballTeamsViewModel.FootBallTeamService = footballBl;
        }
    }
}
