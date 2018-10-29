using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BAL;
using IBAL;
using IDAL;

namespace WpfApp1
{
    public class FootballTeamsViewModel : INotifyPropertyChanged
    {
        public IFootBallTeamService FootBallTeamService { get; set; }
       


        private IList<FootballTeamsData> footballTeams;

        public IList<FootballTeamsData> FootballTeams
        {
            get
            {
                return footballTeams;
            }
            set
            {
                footballTeams = value;
                OnPropertyChanged("FootballTeams");
            }
        }

        private ICommand mLoadCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LoadCommand
        {
            get
            {
                if (mLoadCommand == null)
                    mLoadCommand = new LoadCommand(this);
                return mLoadCommand;
            }
            set
            {
                mLoadCommand = value;
            }
        }

        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }

    public class LoadCommand : ICommand
    {
        #region ICommand Members
        FootballTeamsViewModel viewModel;

        public LoadCommand(FootballTeamsViewModel viewmodel)
        {
            this.viewModel = viewmodel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
         
            //Validate dB Structure
            try
            {
                viewModel.FootBallTeamService.ValidateStructure();
                
            }
            catch (CustomException<InvalidColumnCountException> ex)
            {
                MessageBox.Show(ex.Message);
                Utilities.Utilities.WriteLog(ex.Message);
            }
            catch (CustomException<InvalidColumnNameException> ex)
            {
                // handle your custom exception ...
                MessageBox.Show(ex.Message);
                Utilities.Utilities.WriteLog(ex.Message);
            }
            
            



            viewModel.FootballTeams = viewModel.FootBallTeamService.RetriveTeamDetailsWithLeastDifference();


        }

        #endregion
    }

}
