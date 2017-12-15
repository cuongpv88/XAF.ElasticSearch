﻿// <auto-generated>
// </auto-generated>
namespace BYteWare.XAF.ElasticSearch.Win.Template
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using DevExpress.ExpressApp;
    using DevExpress.ExpressApp.Model;
    using DevExpress.ExpressApp.Templates;
    using DevExpress.ExpressApp.Templates.ActionControls;
    using DevExpress.ExpressApp.Win.Controls;
    using DevExpress.ExpressApp.Win.SystemModule;
    using DevExpress.ExpressApp.Win.Templates;
    using DevExpress.ExpressApp.Win.Templates.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;

    [CLSCompliant(false)]
    public partial class DetailDynamicActionContainerV2 : XtraForm, IActionControlsSite, IContextMenuHolder, IWindowTemplate, IBarManagerHolder, ISupportViewChanged, ISupportUpdate, IViewSiteTemplate, ISupportStoreSettings, IViewHolder, IDynamicContainersTemplate
    {
        private static readonly object viewChanged = new object();
        private static readonly object settingsReloaded = new object();
        private StatusMessagesHelper statusMessagesHelper;

        protected virtual void RaiseViewChanged(DevExpress.ExpressApp.View view)
        {
            ((EventHandler<TemplateViewChangedEventArgs>)Events[viewChanged])?.Invoke(this, new TemplateViewChangedEventArgs(view));
        }
        protected virtual void RaiseSettingsReloaded()
        {
            ((EventHandler)Events[settingsReloaded])?.Invoke(this, EventArgs.Empty);
        }

        public DetailDynamicActionContainerV2()
        {
            InitializeComponent();
            barManager.ForceLinkCreate();
            statusMessagesHelper = new StatusMessagesHelper(barContainerStatusMessages);
        }

        /// <summary>
        /// Returns the Action Container Manager
        /// </summary>
        public ActionContainersManager ActionContainersManager
        {
            get
            {
                return actionContainersManager;
            }
        }

        /// <summary>
        /// Event that is called if an Action Container was changed
        /// </summary>
        public event EventHandler<ActionContainersChangedEventArgs> ActionContainersChanged;

        /// <summary>
        /// Registers the Enumeration of Action Containers
        /// </summary>
        /// <param name="actionContainers">Enumeration of Action Containers</param>
        public void RegisterActionContainers(IEnumerable<IActionContainer> actionContainers)
        {
            if (actionContainers != null)
            {
                ActionContainersManager.ActionContainerComponents.AddRange(actionContainers);
                OnActionContainersChanged(new ActionContainersChangedEventArgs(actionContainers, ActionContainersChangedType.Added));
            }
        }

        /// <summary>
        /// Unregisters the Enumeration of Action Containers
        /// </summary>
        /// <param name="actionContainers">Enumeration of Action Containers</param>
        public void UnregisterActionContainers(IEnumerable<IActionContainer> actionContainers)
        {
            if (actionContainers != null)
            {
                foreach (IActionContainer actionContainer in actionContainers)
                {
                    ActionContainersManager.ActionContainerComponents.Remove(actionContainer);
                }
                OnActionContainersChanged(new ActionContainersChangedEventArgs(actionContainers, ActionContainersChangedType.Removed));
            }
        }

        /// <summary>
        /// Calls the Event Handlers of ActionContainersChanged
        /// </summary>
        /// <param name="e">The ActionContainersChanged Event Arguments to pass</param>
        protected virtual void OnActionContainersChanged(ActionContainersChangedEventArgs e)
        {
            ActionContainersChanged?.Invoke(this, e);
        }

        IEnumerable<IActionControl> IActionControlsSite.ActionControls
        {
            get
            {
                return barManager.ActionControls;
            }
        }

        IEnumerable<IActionControlContainer> IActionControlsSite.ActionContainers
        {
            get
            {
                return barManager.ActionContainers;
            }
        }

        IActionControlContainer IActionControlsSite.DefaultContainer
        {
            get
            {
                return actionContainerView;
            }
        }

        void IFrameTemplate.SetView(DevExpress.ExpressApp.View view)
        {
            viewSiteManager.SetView(view);
            RaiseViewChanged(view);
        }

        ICollection<IActionContainer> IFrameTemplate.GetContainers()
        {
            return actionContainersManager.GetContainers();
        }

        IActionContainer IFrameTemplate.DefaultContainer
        {
            get
            {
                return actionContainersManager.DefaultContainer;
            }
        }

        void IWindowTemplate.SetCaption(string caption)
        {
            Text = caption;
        }

        void IWindowTemplate.SetStatus(ICollection<string> statusMessages)
        {
            statusMessagesHelper.SetMessages(statusMessages);
        }

        bool IWindowTemplate.IsSizeable
        {
            get
            {
                return FormBorderStyle == FormBorderStyle.Sizable;
            }
            set
            {
                FormBorderStyle = (value ? FormBorderStyle.Sizable : FormBorderStyle.FixedDialog);
            }
        }

        BarManager IBarManagerHolder.BarManager
        {
            get
            {
                return barManager;
            }
        }

        event EventHandler IBarManagerHolder.BarManagerChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        PopupMenu IContextMenuHolder.ContextMenu
        {
            get
            {
                return contextMenu;
            }
        }

        event EventHandler<TemplateViewChangedEventArgs> ISupportViewChanged.ViewChanged
        {
            add
            {
                Events.AddHandler(viewChanged, value);
            }
            remove
            {
                Events.RemoveHandler(viewChanged, value);
            }
        }

        void ISupportUpdate.BeginUpdate()
        {
            barManager.BeginUpdate();
        }

        void ISupportUpdate.EndUpdate()
        {
            barManager.EndUpdate();
            barManager.UpdateLayout();
        }

        object IViewSiteTemplate.ViewSiteControl
        {
            get
            {
                return viewSiteManager.ViewSiteControl;
            }
        }

        void ISupportStoreSettings.SetSettings(IModelTemplate settings)
        {
            IModelTemplateWin templateModel = (IModelTemplateWin)settings;
            TemplatesHelper templatesHelper = new TemplatesHelper(templateModel);
            IModelFormState formState;
            if (viewSiteManager.View != null)
            {
                formState = templatesHelper.GetFormStateNode(viewSiteManager.View.Id);
            }
            else
            {
                formState = templatesHelper.GetFormStateNode();
            }
            formStateModelSynchronizer.Model = formState;
        }

        void ISupportStoreSettings.ReloadSettings()
        {
            modelSynchronizationManager.ApplyModel();
            RaiseSettingsReloaded();
        }

        void ISupportStoreSettings.SaveSettings()
        {
            SuspendLayout();
            try
            {
                modelSynchronizationManager.SynchronizeModel();
            }
            finally
            {
                ResumeLayout();
            }
        }

        event EventHandler ISupportStoreSettings.SettingsReloaded
        {
            add
            {
                Events.AddHandler(settingsReloaded, value);
            }
            remove
            {
                Events.RemoveHandler(settingsReloaded, value);
            }
        }

        DevExpress.ExpressApp.View IViewHolder.View
        {
            get
            {
                return viewSiteManager.View;
            }
        }
    }
}