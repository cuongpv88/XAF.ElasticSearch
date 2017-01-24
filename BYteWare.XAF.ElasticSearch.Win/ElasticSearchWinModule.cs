﻿namespace BYteWare.XAF.ElasticSearch.Win
{
    using Controller;
    using DevExpress.ExpressApp;
    using DevExpress.ExpressApp.Editors;
    using DevExpress.ExpressApp.Model;
    using DevExpress.ExpressApp.Updating;
    using DevExpress.ExpressApp.Win;
    using DevExpress.Utils;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using Template;
    using XAF.Win;

    /// <summary>
    /// XAF ElasticSearch Winforms Module
    /// </summary>
    [CLSCompliant(false)]
    [ToolboxItem(true)]
    /*[ToolboxBitmap(typeof(BYteWareModule), "Logo_16x16.bmp")]
    [ToolboxItemFilter("Xaf.Platform.Win")]*/
    [Description("BYteWare ElasticSearch XAF Winforms Module")]
    public sealed class ElasticSearchWinModule : ModuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElasticSearchWinModule" /> class.
        /// </summary>
        public ElasticSearchWinModule()
        {
            WaitScreenWin.Register();
        }

        /// <inheritdoc/>
        public override void Setup(XafApplication application)
        {
            base.Setup(application);
            ((WinApplication)application).FrameTemplateFactory = new TemplateFactory();
        }

        /// <inheritdoc/>
        public override void ExtendModelInterfaces(ModelInterfaceExtenders extenders)
        {
            base.ExtendModelInterfaces(extenders);
            if (extenders == null)
            {
                throw new ArgumentNullException(nameof(extenders));
            }
            extenders.Add<IModelClass, IModelFilterPanel>();
            extenders.Add<IModelListView, IModelListViewFilterPanel>();
        }

        /// <inheritdoc/>
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            return ModuleUpdater.EmptyModuleUpdaters;
        }

        /// <inheritdoc/>
        protected override IEnumerable<Type> GetRegularTypes()
        {
            return new Type[]
            {
                typeof(IModelFilterPanel),
                typeof(IModelListViewFilterPanel),
            };
        }

        /// <inheritdoc/>
        protected override IEnumerable<Type> GetDeclaredExportedTypes()
        {
            return Type.EmptyTypes;
        }

        /// <inheritdoc/>
        protected override IEnumerable<Type> GetDeclaredControllerTypes()
        {
            return new Type[]
            {
                typeof(FilterPanelListViewController),
            };
        }

        /// <inheritdoc/>
        protected override void RegisterEditorDescriptors(EditorDescriptorsFactory editorDescriptorsFactory)
        {
        }

        /// <inheritdoc/>
        protected override ModuleTypeList GetRequiredModuleTypesCore()
        {
            var moduleTypeList = base.GetRequiredModuleTypesCore();
            moduleTypeList.Add(typeof(ElasticSearchModule));
            return moduleTypeList;
        }
    }
}
