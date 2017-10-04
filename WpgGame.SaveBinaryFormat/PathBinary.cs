using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpgGame.SaveBinaryFormat
{
   public static class PathBinary
    {
        private readonly static Dictionary<PathType, string> _pathDictionary;

        static PathBinary()
        {
            _pathDictionary = new Dictionary<PathType, string>();
            Initialize();
        }

        private static void Initialize()
        {
            _pathDictionary.Add(PathType.ViewType, "viewType.dat");
            _pathDictionary.Add(PathType.TabSetting, "TabSetting.dat");
            _pathDictionary.Add(PathType.FilesArchiv, "FilesArchiv.dat");
            _pathDictionary.Add(PathType.CountList, "Count.dat");
            _pathDictionary.Add(PathType.ImageOrList, "ImageOrList.dat");
            _pathDictionary.Add(PathType.Groups1, "Groups1.dat");
            _pathDictionary.Add(PathType.Groups2, "Groups2.dat");
            _pathDictionary.Add(PathType.Groups3, "Groups3.dat");
            _pathDictionary.Add(PathType.Groups4, "Groups4.dat");
            _pathDictionary.Add(PathType.Commands, "Commands.dat");
            _pathDictionary.Add(PathType.StackPanelsThems, "Thems.dat");
            _pathDictionary.Add(PathType.PathFile, "PathFile.dat");
            _pathDictionary.Add(PathType.CurrentGroup, "CurrentGroup.dat");
            _pathDictionary.Add(PathType.CurrentStage, "CurrentStage.dat");
            _pathDictionary.Add(PathType.ListResultDatas, "ListResultDatas.dat");
            _pathDictionary.Add(PathType.Points, "Points.dat");
            _pathDictionary.Add(PathType.OneCurrentGroup, "OneCurrentGroup.dat");
            _pathDictionary.Add(PathType.TheeePoints, "TheeePoints.dat");
            _pathDictionary.Add(PathType.StageThree, "StageThree.dat");
            _pathDictionary.Add(PathType.BoolStageTree, "BoolStageTree.dat");
            _pathDictionary.Add(PathType.AllCommands, "AllCommands.dat");
            _pathDictionary.Add(PathType.IndexCommands, "IndexCommands.dat");
            _pathDictionary.Add(PathType.WinCommandsStageThree, "WinCommandsStageThree.dat");
            _pathDictionary.Add(PathType.NomerCommandsForFifeStage, "NomerCommandsForFifeStage.dat");
            //NomerCommandsForFifeStage
            //_stagefour
            //StageThree

        }

        public static string GetPath(PathType type)
        {
            if (_pathDictionary.ContainsKey(type))
            {
                return _pathDictionary[type];
            }

            return null;
        }




    }
}
