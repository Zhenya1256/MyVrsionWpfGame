using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGame.OpenArchive;
using WpfGme.UiEntites.GamePlay;

namespace WpfGame.OpenArchive.Implement
{
   public class ArchiveLoader : IArchiveLoader
    {
        private IArhiveVolidator _volidate;
        private IStageBuilder _builder;

        public ArchiveLoader()
        {
            _volidate = new ArchiveValidator();
            _builder = new StageBuilder();
        }



        public IDataResult<LoaderEntyity>
            DataResult(FilesEntety files)
        {         

              IDataResult <LoaderEntyity> dataResult = 
                new DataResult<LoaderEntyity>();
            List<IResult> listResults = new List<IResult>();
            IResult validationResult = _builder.BuildStage(files);
            //ComponentLoadEvent.Invoke(validationResult.Message);
            listResults.Add(validationResult);
            validationResult = _builder.BuildSub(files);
            listResults.Add(validationResult);
            validationResult = _builder.BuildPicture(files);
            listResults.Add(validationResult);
            validationResult = _builder.BuildNameThems(files);
            listResults.Add(validationResult);
            validationResult = _builder.BuildFileWithPicture(files);
            listResults.Add(validationResult);
            validationResult = _builder.BuildFileWithData(files);
            listResults.Add(validationResult);
            validationResult = _builder.BuildDescription(files);
            listResults.Add(validationResult);
            //TODO Add validation for current component and set it with builder
            // Generate totola IResult and set data of result entity
            //_volidate.
            dataResult.Success = true;

            foreach (IResult item in listResults)
            {
                if (!item.Success)
                {
                    dataResult.Message += item.Message +"\n";
                    dataResult.Success = false;
                }
            }

            if (dataResult.Success)
            {
                dataResult.Data = _builder.GetInstance(files);
                dataResult.Message = " загрузка та перевірка даних прошла успішно, можене починати гру";
            }       

            return dataResult;
        }
    }
}
