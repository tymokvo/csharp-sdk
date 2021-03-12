using System.Collections.Generic;

namespace PollinationSDK.Interface.Io.Inputs
{
    public partial interface IStep : IoBase
    {
        List<AnyOf<DAGGenericInputAlias, DAGStringInputAlias, DAGIntegerInputAlias, DAGNumberInputAlias, DAGBooleanInputAlias, DAGFolderInputAlias, DAGFileInputAlias, DAGPathInputAlias, DAGArrayInputAlias, DAGJSONObjectInputAlias, DAGLinkedInputAlias>> Alias { get; set; }
    }

}
