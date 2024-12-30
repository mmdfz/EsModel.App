using System;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.swpublished;

namespace SolidWorksAddin
{
    public class SolidWorksAddin : ISwAddin
    {
        private SldWorks _swApp;
        private int _addInCookie;

        #region ConnectToSW

        public bool ConnectToSW(object swAppObj, int SessionCookie)
        {
            _swApp = (SldWorks)swAppObj;
            _addInCookie = SessionCookie;

            _swApp.SetAddinCallbackInfo(0, this, _addInCookie);

            BuildMenu();

            return true;
        }

        public bool DisconnectFromSW()
        {
            DestroyMenu();
            return true;
        }

        private void BuildMenu()
        {
            int docType = (int)swDocumentTypes_e.swDocNONE;
            _swApp.AddMenu(docType, "至易测试", 1); 
            _swApp.AddMenuItem4(docType, _addInCookie, "打开至易测试窗体@至易测试", 1, "OpenTestForm", "3", "打开至易测试窗体", "");
        }

        private void DestroyMenu()
        {
            int docType = (int)swDocumentTypes_e.swDocNONE;
            _swApp.RemoveMenu(docType, "至易测试", "OpenTestForm");
        }

        #endregion

        #region Add-in Implementation

        public void OpenTestForm()
        {
            IntPtr swMainWindowHandle = (IntPtr)_swApp.GetProcessID();

            var swFrame = new swFrame(swMainWindowHandle);
            var form = new TestForm(_swApp);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(swFrame);  
        }

        #endregion
    }
    public class swFrame : IWin32Window
    {
        public IntPtr Handle { get; set; }

        public swFrame(IntPtr handle)
        {
            Handle = handle;
        }
    }
}
