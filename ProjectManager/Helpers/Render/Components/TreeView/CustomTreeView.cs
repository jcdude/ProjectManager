using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjectManager.Helpers.Render.Components
{
    public abstract class CustomTreeView : ITreeView
    {
        public CustomTreeView(string parentLiFormat = "<li>{0}</li>", string childLiFormat = "<li>{0}</li>")
        {
            this.liParent = parentLiFormat;
            this.liChild = childLiFormat;
        }
    }
}