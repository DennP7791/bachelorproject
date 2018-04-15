using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace InfoViewer
{
    public class InfoViewer
    {
        private InfoViewerGateway.InfoViewerGateway gateway;
        public void Start()
        {
            gateway = new InfoViewerGateway.InfoViewerGateway();
        }
    }
}
