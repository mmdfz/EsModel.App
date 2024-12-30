using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System.Collections;
using System.Reflection;
using SolidWorks.Interop.swpublished;
using System.Diagnostics;
using System.Windows.Forms;
using SolidWorksTools;
using SolidWorksTools.File;


namespace EsModleApp
{
    [Guid("960703D3-350C-4BAB-9CF0-E1C3D92CCFD2")]
    [ComVisible(true)]
    public class SolidWorksAddin : ISwAddin
    {
        private SldWorks _swApp;
        private int _addInID;
        private ICommandManager _cmdMgr;

        public bool ConnectToSW(object ThisSW, int cookie)
        {
            _swApp = (SldWorks)ThisSW;
            _cmdMgr = _swApp.GetCommandManager(cookie);
            AddToolbarButton();

            return true;
        }

        public bool DisconnectFromSW()
        {
            return true;
        }

        private void AddToolbarButton()
        {
            var cmdGroup = _cmdMgr.CreateCommandGroup2(0, "至易测试", "至易测试插件", "", -1, false, false, false);

            var button = cmdGroup.AddButton(1, "进行测试", "测试项目1", "", 0, -1);

            button.OnClick += OpenTestForm;

            cmdGroup.AddToUI();
        }
        private void OpenTestForm()         // 打开窗体
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }
    }
}
