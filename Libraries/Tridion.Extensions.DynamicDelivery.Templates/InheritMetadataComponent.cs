﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tridion.ContentManager.Templating.Assembly;
using Tridion.ContentManager.CommunicationManagement;
using Dynamic = Tridion.Extensions.DynamicDelivery.ContentModel;
using TCM = Tridion.ContentManager.ContentManagement;

namespace Tridion.Extensions.DynamicDelivery.Templates
{
   [TcmTemplateTitle("Add inherited metadata to component")]
   public partial class InheritMetadataComponent : ComponentTemplateBase
   {
      protected Dynamic.MergeAction defaultMergeAction = Dynamic.MergeAction.Skip;
      protected override void TransformComponent(Dynamic.Component component)
      {

         TCM.Component tcmComponent = this.GetTcmComponent();
         TCM.Folder tcmFolder = (TCM.Folder)tcmComponent.OrganizationalItem;

         String mergeActionStr = Package.GetValue("MergeAction");
         Dynamic.MergeAction mergeAction;
         if (string.IsNullOrEmpty(mergeActionStr))
         {
            mergeAction = defaultMergeAction;
         }
         else
         {
            mergeAction = (Dynamic.MergeAction)Enum.Parse(typeof(Dynamic.MergeAction), mergeActionStr);
         }

         while (tcmFolder.OrganizationalItem != null)
         {
            if (tcmFolder.MetadataSchema != null)
            {
               TCM.Fields.ItemFields tcmFields = new TCM.Fields.ItemFields(tcmFolder.Metadata, tcmFolder.MetadataSchema);
               // change
              Builder.FieldsBuilder.AddFields(component.MetadataFields, tcmFields, 1, false, mergeAction, manager);
                
            }
            tcmFolder = (TCM.Folder)tcmFolder.OrganizationalItem;
         }

      }
   }
}
