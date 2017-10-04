using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGame.Data;
using WpfGame.WorkWithCommad.Implement;

namespace WpfGame.ViewModal.ViewModelStage
{
    public class RandomCreateCommands
    {
        public RandomCreateCommands(List<TeamGroup> data)
        {
            List<TeamGroup> fe = data;
            if (data.Count != 0)
            {
                CreateCommands(data);
            }

        }

        Random _random = new Random();
        List<TeamGroup> commands = new List<TeamGroup>();
        static List<TeamGroup> commands1 = new List<TeamGroup>();

        static List<TeamGroup> commands2 = new List<TeamGroup>();
        static List<TeamGroup> commands3 = new List<TeamGroup>();
        static List<TeamGroup> commands4 = new List<TeamGroup>();
        ObservableCollection<List<TeamGroup>> listCommands = new ObservableCollection<List<TeamGroup>>();

        public List<TeamGroup> CommandsOne
        {
            get { return commands1; }
        }

        public List<TeamGroup> CommandsTwo
        {
            get { return commands2; }
        }

        public List<TeamGroup> CommandsThree
        {
            get { return commands3; }
        }

        public List<TeamGroup> CommandsFour
        {
            get { return commands4; }
        }

        private void CreateListCommands(List<TeamGroup> data)
        {
            listCommands.Add(commands1);
            listCommands.Add(commands2);
            listCommands.Add(commands3);
            listCommands.Add(commands4);

            foreach (var s in data)
            {
                commands.Add(s);
            }

        }

        private int RandomGenerete()
        {
            if (commands.Count == 0)
            {
                return 0;
            }

            return _random.Next(0, commands.Count - 1);
        }

        public void CreateCommands(List<TeamGroup> data)
        {
            CreateListCommands(data);

            foreach (var item in listCommands)
            {
                while (item.Count != 4)
                {

                    int index = RandomGenerete();

                    if (commands.Count != 0)
                    {
                        item.Add(commands[index]);
                        commands.Remove(commands[index]);                       
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
