using Jysk2_0.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jysk2_0.ToastrHelper
{
    public enum ToastType
    {
        Error,
        Info,
        Success,
        Warning
    }

    [Serializable]
    public class ToastMessage
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public ToastType ToastType { get; set; }
        public bool IsSticky { get; set; }
    }

    [Serializable]
    public class Toastr
    {
        public bool ShowNewestOnTop { get; set; }
        public bool ShowCloseButton { get; set; }
        public List<ToastMessage> ToastMessages { get; set; }

        public ToastMessage AddToastMessage(string title, string message, ToastType toastType)
        {
            var toast = new ToastMessage()
            {
                Title = title,
                Message = message,
                ToastType = toastType
            };
            ToastMessages.Add(toast);
            return toast;
        }

        public Toastr()
        {
            ToastMessages = new List<ToastMessage>();
            ShowNewestOnTop = false;
            ShowCloseButton = false;
        }
    }

    public static class ControllerExtensions
    {
        public static ToastMessage AddToastMessage(this Controller controller, string title, string message, ToastType toastType = ToastType.Info)
        {
            Toastr toastr = controller.TempData["Toastr"] as Toastr;
            toastr = toastr ?? new Toastr();

            var toastMessage = toastr.AddToastMessage(title, message, toastType);
            controller.TempData["Toastr"] = toastr;
            return toastMessage;
        }
    }

    public class MessagesActionFilter : ActionFilterAttribute
    {
        // This method is called BEFORE the action method is executed
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Check for incoming Toastr objects, in case we've been redirected here
            AbstractMessageController controller = filterContext.Controller as AbstractMessageController;
            if (controller != null)
                controller.Toastr = (controller.TempData["Toastr"] as Toastr) ?? new Toastr();

            base.OnActionExecuting(filterContext);
        }

        // This method is called AFTER the action method is executed but BEFORE the
        // result is processed (in the view or in the redirection)
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            AbstractMessageController controller = filterContext.Controller as AbstractMessageController;
            if (controller != null) {
                if (filterContext.Result.GetType() == typeof(ViewResult) || 
                    filterContext.Result.GetType() == typeof(PartialViewResult) )
                {
                    if (controller.Toastr != null && controller.Toastr.ToastMessages != null && controller.Toastr.ToastMessages.Count() > 0)
                    {
                        // We're going to a view so we store Toastr in the ViewData collection
                        controller.ViewData["Toastr"] = controller.Toastr;
                    }
                }
                else if (filterContext.Result.GetType() == typeof(RedirectToRouteResult) ||
                    filterContext.Result.GetType() == typeof(JavaScriptResult))
                {
                    if (controller.Toastr != null && controller.Toastr.ToastMessages.Count() > 0)
                    {
                        // User is being redirected to another action method so we store Toastr in
                        // the TempData collection
                        controller.TempData["Toastr"] = controller.Toastr;
                    }
                }
            }

            base.OnActionExecuted(filterContext);
        }
    }
}