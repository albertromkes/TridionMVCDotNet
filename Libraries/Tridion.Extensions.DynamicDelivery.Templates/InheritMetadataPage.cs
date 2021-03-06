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
   [TcmTemplateTitle("Add inherited metadata to page")]
   public partial class InheritMetadataPage : PageTemplateBase
   {
      protected Dynamic.MergeAction defaultMergeAction = Dynamic.MergeAction.Skip;
     
      protected override void TransformPage(Dynamic.Page page)
      {
         Page tcmPage = this.GetTcmPage();
         StructureGroup tcmSG = (StructureGroup)tcmPage.OrganizationalItem;
         
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

         while (tcmSG.OrganizationalItem != null)
         {
            if (tcmSG.MetadataSchema != null)
            {
               TCM.Fields.ItemFields tcmFields = new TCM.Fields.ItemFields(tcmSG.Metadata, tcmSG.MetadataSchema);
               // change
               Builder.FieldsBuilder.AddFields(page.Metadata, tcmFields, 1, false, mergeAction, manager);
            }
            tcmSG = (StructureGroup)tcmSG.OrganizationalItem;
         }

      }
   }
}
