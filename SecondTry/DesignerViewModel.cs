using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.Activities.Core.Presentation;
using System.Activities.Presentation;
using System.Activities.Presentation.Metadata;
using System.Activities.Presentation.Toolbox;
using System.Windows.Input;

namespace SecondTry
{
    class DesignerViewModel
    {
        public ICommand NewCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand SaveAsCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public string FileName
        {
            get
            {
                return this.FileName;
            }

            private set
            {
                this.fileName = value;
                this.Title = string.Format("{0} - {1}", title, this.FileName);
            }
        }

        public WorkflowDesigner RehostedWFDesigner
        {
            get
            {
                return this.rehostedWFDesigner;
            }

            private set
            {
                this.rehostedWFDesigner = value;
                this.NotifyChanged("WorkflowDesignerControl");
                this.NotifyChanged("WorkflowPropertyControl");
            }
        }

        public object WorkflowDesignerControl
        {
            get
            {
                return this.RehostedWFDesigner.View;
            }
        }

        public object WorkflowPropertyControl
        {
            get
            {
                return this.RehostedWFDesigner.PropertyInspectorView;
            }
        }

        public string XAML
        {
            get
            {
                if (this.RehostedWFDesigner.Text != null)
                {
                    this.RehostedWFDesigner.Flush();
                    return this.RehostedWFDesigner.Text;
                }

                return null;
            }
        }
    }


}
