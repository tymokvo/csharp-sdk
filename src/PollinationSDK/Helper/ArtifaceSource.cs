using PollinationSDK.Model;

namespace PollinationSDK
{

    public class ArtifaceSourcePath: ProjectFolderSource
    {
     
        public ArtifaceSourcePath(string relativePath):base(path:"project_folder/" + relativePath.Replace('\\', '/'))
        {
        }

        public override string ToString() => ToJson();
    }


}
