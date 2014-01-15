// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4Mvc;
namespace Magenic.BadgeApplication.Controllers
{
    public partial class ActivitiesController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActivitiesController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ActivitiesController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }


        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActivitiesController Actions { get { return Mvc.Activities; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Activities";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Activities";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string SubmitActivityForm = "SubmitActivityForm";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string SubmitActivityForm = "SubmitActivityForm";
        }


        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string _PreviousActivities = "_PreviousActivities";
                public readonly string Index = "Index";
            }
            public readonly string _PreviousActivities = "~/Views/Activities/_PreviousActivities.cshtml";
            public readonly string Index = "~/Views/Activities/Index.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_ActivitiesController : Magenic.BadgeApplication.Controllers.ActivitiesController
    {
        public T4MVC_ActivitiesController() : base(Dummy.Instance) { }

        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }

        partial void SubmitActivityFormOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> SubmitActivityForm()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SubmitActivityForm);
            SubmitActivityFormOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
