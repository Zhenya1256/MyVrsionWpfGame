using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGame.StageFour.ViewModel;
using WpfGame.ViewModal.StaticClass;
using WpfGame.ViewModal.TempDir;
using WpfGame.WorkWithCommad.Implement;
using WpgGame.SaveBinaryFormat;

namespace WpfGame.ViewModal.Stages
{
    public class ChangeStage
    {

        public static void SecondStage()
        {
            List<TeamGroup> list1 = new List<TeamGroup>();
            List<TeamGroup> list2 = new List<TeamGroup>();
            List<TeamGroup> list3 = new List<TeamGroup>();
            List<TeamGroup> list4 = new List<TeamGroup>();
            List<List<TeamGroup>> lists = new List<List<TeamGroup>>();
            lists.Add(list1);
            lists.Add(list2);
            lists.Add(list3);
            lists.Add(list4);
            int i = 0;
            string point = Binary.Read(PathType.Points);

            if (point == null)
            {
                foreach (var s in lists)
                {
                    int a = 0;
                    List<TeamGroup> g1 = Binary.ReadTeamGroup(PathType.Groups1);
                    foreach (var t in g1.
                        OrderByDescending((x) => x.Point))
                    {
                        if (i == a)
                        {
                            s.Add(t);
                            break;
                        }
                        a++;
                    }
                    a = 0;
                    List<TeamGroup> g2 = Binary.ReadTeamGroup(PathType.Groups2);
                    foreach (var t in g2.
                       OrderByDescending((x) => x.Point))
                    {
                        if (i == a)
                        {
                            s.Add(t);
                            break;
                        }
                        a++;
                    }
                    a = 0;
                    List<TeamGroup> g3 = Binary.ReadTeamGroup(PathType.Groups3);
                    foreach (var t in g3.
                       OrderByDescending((x) => x.Point))
                    {
                        if (i == a)
                        {
                            s.Add(t);
                            break;
                        }
                        a++;
                    }
                    a = 0;
                    List<TeamGroup> g4 = Binary.ReadTeamGroup(PathType.Groups4);

                    foreach (var t in g4.
                       OrderByDescending((x) => x.Point))
                    {
                        if (i == a)
                        {
                            s.Add(t);
                            break;
                        }
                        a++;
                    }

                    i++;
                }


                for (int k = 0; k < 4; k++)
                {
                    list1[k].Point = 0;
                    list2[k].Point = 0;
                    list3[k].Point = 0;
                    list4[k].Point = 0;
                }

                Binary.Write("1", PathType.Points);

                TempGrops.groups1.Clear();
                TempGrops.groups2.Clear();
                TempGrops.groups3.Clear();
                TempGrops.groups4.Clear();
                TempGrops.groups1.AddRange(list1);
                TempGrops.groups2.AddRange(list2);
                TempGrops.groups3.AddRange(list3);
                TempGrops.groups4.AddRange(list4);

                Binary.Clear(PathType.Groups1);
                Binary.Write(list1.ToList(), PathType.Groups1);
                Binary.Clear(PathType.Groups2);
                Binary.Write(list2.ToList(), PathType.Groups2);
                Binary.Clear(PathType.Groups3);
                Binary.Write(list3.ToList(), PathType.Groups3);
                Binary.Clear(PathType.Groups4);
                Binary.Write(list4.ToList(), PathType.Groups4);
            }
        }

        public static void ThridStage()
        {
            string point = Binary.Read(PathType.TheeePoints);
            List<TeamGroup> threeGroup = new List<TeamGroup>();
            if (point == null)
            {
                List<TeamGroup> g1 = Binary.ReadTeamGroup(PathType.Groups1);

                int i = 0;
                foreach (var t in g1.
                    OrderByDescending((x) => x.Point))
                {
                    i++;
                    if (i == 4)
                    {
                        threeGroup.Add(t);
                    }
                }
                i = 0;
                List<TeamGroup> g2 = Binary.ReadTeamGroup(PathType.Groups2);

                foreach (var t in g2.
                       OrderByDescending((x) => x.Point))
                {
                    i++;
                    if (i >= 3)
                    {
                        threeGroup.Add(t);
                    }

                }

                i = 0;
                List<TeamGroup> g3 = Binary.ReadTeamGroup(PathType.Groups3);

                foreach (var t in g3.
                       OrderByDescending((x) => x.Point))
                {
                    i++;
                    if (i >= 2)
                    {
                        threeGroup.Add(t);
                    }
                }

                i = 0;
                List<TeamGroup> g4 = Binary.ReadTeamGroup(PathType.Groups4);

                foreach (var t in g4.
                       OrderByDescending((x) => x.Point))
                {
                    i++;
                    if (i >= 2)
                    {
                        threeGroup.Add(t);
                    }
                }

                foreach(var s in threeGroup)
                {
                    s.Point = 0;
                }

                Binary.Write("1", PathType.TheeePoints);
                Binary.Clear(PathType.Points);
                Binary.Clear(PathType.StageThree);
                Binary.Write(threeGroup.ToList(), PathType.StageThree);
            }
        }

        public static void FourStage()
        {
    
            TeamGroup command =
                Binary.CurrentTeam(PathType.WinCommandsStageThree);
            List<TeamGroup> list1 = new List<TeamGroup>();
            List<TeamGroup> list2 = new List<TeamGroup>();
            string point = Binary.Read(PathType.Points);

            if (point == null)
            {
                
                int a = 0;
                List<TeamGroup> g1 = Binary.ReadTeamGroup(PathType.Groups1);
                foreach (var t in g1.
                   OrderByDescending((x) => x.Point))
                {
                    if (a == 0)
                    {
                        list1.Add(t);
                    }
                    else if (a <= 2 && a != 0)
                    {
                        list2.Add(t);
                    }
                    a++;
                }
                a = 0;
                List<TeamGroup> g2 = Binary.ReadTeamGroup(PathType.Groups2);
                foreach (var t in g2.
                   OrderByDescending((x) => x.Point))
                {
                    if (a < 2)
                    {
                        list1.Add(t);
                    }
                    a++;
                }

                List<TeamGroup> g3 = Binary.ReadTeamGroup(PathType.Groups3);
                foreach (var t in g3.
                   OrderByDescending((x) => x.Point))
                {
                    list1.Add(t);
                    break;
                }
                List<TeamGroup> g4 = Binary.ReadTeamGroup(PathType.Groups4);
                foreach (var t in g4.
                   OrderByDescending((x) => x.Point))
                {
                    list2.Add(t);
                    break;
                }

                list2.Add(command);
                for (int k = 0; k < 4; k++)
                {
                    list1[k].Point = 0;
                    list2[k].Point = 0;
                }

                Binary.Write("1", PathType.Points);

                TempGrops.groups1.Clear();
                TempGrops.groups2.Clear();
                TempGrops.groups3.Clear();
                TempGrops.groups4.Clear();
                TempGrops.groups1.AddRange(list1);
                TempGrops.groups2.AddRange(list2);

                Binary.Clear(PathType.Groups1);
                Binary.Write(list1.ToList(), PathType.Groups1);
                Binary.Clear(PathType.Groups2);
                Binary.Write(list2.ToList(), PathType.Groups2);
                Binary.Clear(PathType.Groups3);
                Binary.Clear(PathType.Groups4);

            }
        }

        public static void FifeStage()
        {
            //TeamGroup command = null;
            List<TeamGroup> list1 = new List<TeamGroup>();
            List<TeamGroup> g1 = Binary.ReadTeamGroup(PathType.Groups1);
            List<TeamGroup> g2 = Binary.ReadTeamGroup(PathType.Groups2);
            //commands = commands / 2;

            for (int i = 0; i < g1.Count; i++)
            {
                list1.Add(g1[i]);
            }
            for (int i = 0; i < g2.Count; i++)
            {
                list1.Add(g2[i]);
            }

            //for (int k = 0; k < 4; k++)
            //{
            //    list1[k].Point = 0;
            //}


            Binary.Clear(PathType.Groups1);
            //PathType.Groups1
            //Binary.Write(list1.ToList(), PathType.Groups1);
            Binary.Write(list1.ToList(), PathType.Groups1);
            //   Binary.Clear(PathType.Groups2);
        }

        public static void ViewINfoTypeRight(bool answer,string command, 
           int _second)
        {
            string name = command;
            Group.ResulGroups = new TeamGroup(name);
            Grop(name, answer, _second, PathType.Groups2,1);
            Grop(name, answer, _second, PathType.Groups3,1);
            Grop(name, answer, _second, PathType.Groups4,1);
            Grop(name, answer, _second,PathType.Groups1,1);

        }

        private static void Grop(string name,bool answer,double _second,
            PathType type,int k)
        {
            List<TeamGroup> groups1 = Binary.ReadTeamGroup(type);

            if (groups1.Count == 0)
            {
                groups1 = TempGrops.groups1;
            }
            for (int i = 0; i < groups1.Count; i++)
            {
                if (name.Equals(groups1[i].Name))
                {
                    if (answer)
                    {
                        groups1[i].Point += (int)_second * k;
                        Group.ResulGroups.Point = (int)_second * k;

                        Binary.Clear(type);
                        Binary.Write(groups1.ToList(), type);
                        Binary.Clear(PathType.CurrentGroup);
                        Binary.Write(groups1.ToList(), PathType.CurrentGroup);
                    }
                    Binary.Clear(PathType.OneCurrentGroup);
                    Binary.Write(Group.ResulGroups, PathType.OneCurrentGroup);
                    break;
                }
            }

        }

        public static void ThreeStageInfo(bool answer , string command,
           int _second)
        {
            Group.ResulGroups = new TeamGroup(command);
            string name = command;
            Group.TeamGroups = Binary.ReadTeamGroup(PathType.StageThree);
            List<TeamGroup> groups = Group.TeamGroups;

            foreach (var s in groups)
            {
                if (s.Name.Equals(name))
                {
                    if (answer)
                    {
                        Group.ResulGroups.Point = (int)_second;
                        s.Point += (int)_second;
                    }

                    Binary.Clear(PathType.StageThree);
                    Binary.Write(groups.ToList(), PathType.StageThree);
                    Binary.Clear(PathType.CurrentGroup);
                    Binary.Write(groups.ToList(), PathType.CurrentGroup);
                    Binary.Clear(PathType.OneCurrentGroup);
                    Binary.Write(Group.ResulGroups, PathType.OneCurrentGroup);
                    break;
                }
            }
        }

        public static ResultQuation FoueStageINfo(int nomerQuation, TeamGroup team,
            double _second,bool answer)
        {

            Group.ResulGroups = team;
            ResultQuation result = new ResultQuation();
            result.NomerQuation = nomerQuation;
            #region OldLogic
            //if (GetNomer(nomerQuation) <= 2)
            //{
            //    if (answer)
            //    {
            //        Grop(team.Name, answer, _second, PathType.Groups1, 1);
            //        Grop(team.Name, answer, _second, PathType.Groups2, 1);
            //        result.Right = true;                 
            //    }
            //    else
            //    {
            //        result.Right = false;
            //    }
            //}
            //else if (GetNomer(nomerQuation)==3 
            //    || nomerQuation%8==0)
            //{
            //    if (answer)
            //    {
            //        Grop(team.Name, answer, _second, PathType.Groups1, 2);
            //        Grop(team.Name, answer, _second, PathType.Groups2, 2);
            //        result.Right = true;
            //    }
            //  else  if (_second <= 12.1 || !answer)
            //    {
            //        Grop(team.Name, true, 12, PathType.Groups1, -2);
            //        Grop(team.Name, true, 12, PathType.Groups2, -2);
            //        result.Right = false;
            //    }
            //}
            //else
            //{
            //    if (answer)
            //    {
            //        Grop(team.Name, answer, _second, PathType.Groups1, 3);
            //        Grop(team.Name, answer, _second, PathType.Groups2, 3);
            //        result.Right = true;
            //    }
            //    else
            //    {
            //        Grop(team.Name, answer, _second, PathType.Groups1, -3);
            //        Grop(team.Name, answer, _second, PathType.Groups2, -3);
            //        result.Right = false;
            //    }
            //}
            #endregion

            Dictionary<int, int> values = LoadValuePicture.ValuePicture();

            int x = values[nomerQuation];
            if (answer)
            {
                Grop(team.Name, answer, _second, PathType.Groups1, x);
                Grop(team.Name, answer, _second, PathType.Groups2, x);
                result.Right = true;
            }
            else
            {
                if (x == 2)
                {
                    if (_second <= 12.1 || !answer)
                    {
                        Grop(team.Name, true, 12, PathType.Groups1, -2);
                        Grop(team.Name, true, 12, PathType.Groups2, -2);
                    }
                }
                else if (x == 3)
                {
                  
                        Grop(team.Name, answer, _second, PathType.Groups1, -3);
                        Grop(team.Name, answer, _second, PathType.Groups2, -3);                
                }

                result.Right = false;
            }
            
           

            Binary.Clear(PathType.OneCurrentGroup);
            Binary.Write(Group.ResulGroups, PathType.OneCurrentGroup);

            return result;
        }

        private static int GetNomer(int nomarQuat)
        {
            if (nomarQuat <= 5)
            {
                return nomarQuat;
            }

            while(nomarQuat > 5)
            {
                nomarQuat = nomarQuat - 4;
            }

            return nomarQuat;
        }

    }
}
