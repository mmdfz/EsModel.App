using System;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace EsModleApp
{
    public abstract class DocumentEventHandler
    {
        protected SldWorks SwApp;
        protected ModelDoc2 Document;

        public DocumentEventHandler(ModelDoc2 doc, SldWorks app)
        {
            Document = doc;
            SwApp = app;

            AttachEventHandlers();
        }

        public virtual void AttachEventHandlers()
        {
            Document.DestroyNotify += OnDestroy;
            Document.SaveNotify += OnSave;
        }

        public virtual void DetachEventHandlers()
        {
            Document.DestroyNotify -= OnDestroy;
            Document.SaveNotify -= OnSave;
        }

        // 文档被销毁时的处理
        protected virtual int OnDestroy()
        {
            DetachEventHandlers();
            return 0; // 返回 0 表示处理成功
        }

        // 文档保存时的处理
        protected virtual int OnSave()
        {
            SwApp.SendMsgToUser("Document is being saved.");
            return 0; // 返回 0 表示处理成功
        }
    }
}
