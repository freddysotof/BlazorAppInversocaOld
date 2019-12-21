
using BlazorAppInversoca.Shared.Components_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorAppInversoca.Shared.Helpers
{
    public static class StaticComponents
    {

        public static ButtonModelView btnCancel = new ButtonModelView() { name = "Cancelar ", attribute = "button ", isEnabled = true, icon = "cancel" };
        public static ButtonModelView btnFilter = new ButtonModelView() { name = "Buscar ", attribute = "button ", isEnabled = true, icon = "filter_list" };
        public static ButtonModelView btnReset = new ButtonModelView() { name = "Ver Todos ", attribute = "button ", isEnabled = true, icon = "ballot" };
        public static List<NavStepModelView> CrearNavigatorSteps(string[] pasos) {
        List<NavStepModelView> steps = new List<NavStepModelView>();
        foreach (var paso in pasos)
        {
            var separador = paso.Split(',');
            steps.Add(new NavStepModelView { Id = int.Parse(separador[0]), Name = separador[1], 
                Attribute = separador[2], isCurrent = Convert.ToBoolean(separador[3]), 
                isEnabled = Convert.ToBoolean(separador[4]), isCompleted = Convert.ToBoolean(separador[5]) });
        }
        return steps;
        }
        public static ConfirmationModelView NotAuthorizedConfirm = new ConfirmationModelView
        {
            Mensaje = "Usted no esta autorizado para ver este contenido, favor inicie sesion",
            Titulo = "Aviso",
            TipoMensaje = ConfirmationModelView.TiposMensaje.info
        };
        public static ConfirmationModelView DeleteConfirm = new ConfirmationModelView
        {
            Mensaje = "El Registro ha sido eliminado con exito",
            Titulo = "Aviso",
            TipoMensaje = ConfirmationModelView.TiposMensaje.success
        };
        public static ConfirmationModelView InactiveConfirm = new ConfirmationModelView
        {
            Mensaje = "El Registro ha sido desactivado con exito",
            Titulo = "Aviso",
            TipoMensaje = ConfirmationModelView.TiposMensaje.success
        };

        public static List<FilterModelView> createFiltros(string[] nombres)
        {
            List<FilterModelView> filtros = new List<FilterModelView>();
            foreach (var nombre in nombres)
            {
                var separador = nombre.Split(',');
                filtros.Add(new FilterModelView { name = separador[0], type = separador[1], attribute = separador[2] });
            }
            return filtros;
        }
        public static List<HeaderModelView> createTableHeader(string[] nombres)
        {
            List<HeaderModelView> headers = new List<HeaderModelView>();
            foreach (var nombre in nombres)
            {
                var separador = nombre.Split(',');
                headers.Add(new HeaderModelView { headername = separador[0], headerNumber = Convert.ToInt32(separador[1]), headerattribute = separador[2] });
            }
            return headers;
        }
        public static ConfirmationModelView createActiveConfirmation(string nombre)
        {
            nombre = StaticHelper.FirstLetterCapital(nombre);
            return new ConfirmationModelView
            {
                Mensaje = nombre+ " ya existe, pero esta inactivo de manera temporal...\n" +
                "Desea activar nuevamente " + nombre + "?",
                Titulo = "Confirmacion",
                Action = "Activar",
                TipoMensaje = ConfirmationModelView.TiposMensaje.question
            };
        }
        public static ConfirmationModelView createInactiveConfirmation(string nombre)
        {
            nombre = StaticHelper.FirstLetterCapital(nombre);
            return new ConfirmationModelView
            {
                Mensaje = nombre + " tiene registros relacionados, se recomienda desactivar temporalmente",
                Titulo = "Aviso",
                Action = "Desactivar",
                TipoMensaje = ConfirmationModelView.TiposMensaje.info
            };
        }

        public static ConfirmationModelView createSaveConfirm(string mensaje)
        {
            var save = "";
            if (mensaje.ToLower().StartsWith("la"))
            { save = "registrada"; }
            else if (mensaje.ToLower().StartsWith("el"))
            { save = "registrado"; }
            mensaje = StaticHelper.FirstLetterCapital(mensaje);
            return new ConfirmationModelView
            {
                Mensaje = mensaje+" ha sido "+save+" con exito",
                Titulo = "Aviso",
                TipoMensaje = ConfirmationModelView.TiposMensaje.success
            };
        }
        public static ConfirmationModelView createActiveConfirm(string mensaje)
        {
            var save = "";
            if (mensaje.ToLower().StartsWith("la"))
            { save = "reactivada"; }
            else if (mensaje.ToLower().StartsWith("el"))
            { save = "reactivado"; }
            mensaje = StaticHelper.FirstLetterCapital(mensaje);
            return new ConfirmationModelView
            {
                Mensaje = mensaje + " ha sido " + save + " con exito",
                Titulo = "Aviso",
                TipoMensaje = ConfirmationModelView.TiposMensaje.success
            };
        }
        public static ConfirmationModelView createUpdateConfirm(string mensaje)
        {
            var save = "";
            if (mensaje.ToLower().StartsWith("la"))
            { save = "modificada"; }
            else if (mensaje.ToLower().StartsWith("el"))
            { save = "modificado"; }
            mensaje = StaticHelper.FirstLetterCapital(mensaje);
            return new ConfirmationModelView
            {
                Mensaje = mensaje + " ha sido " + save + " con exito",
                Titulo = "Aviso",
                TipoMensaje = ConfirmationModelView.TiposMensaje.success
            };
        }
        public static SlideToggleModelView sliderActivo()
        { return new SlideToggleModelView { Name = "Solo Activos", isChecked = true, isEnabled = true }; }
        public static SlideToggleModelView sliderInactivo()
        { return new SlideToggleModelView { Name = "Solo Inactivos", isChecked = false, isEnabled = true }; }
        public static SlideToggleModelView sliderTodo()
        { return new SlideToggleModelView { Name = "Todos", isChecked = false, isEnabled = true }; }
        public static ButtonModelView btnSave(string nombre = "", string attr = "")
        { return new ButtonModelView() { name = "Salvar " + nombre, attribute = "button " + attr, isEnabled = true, icon = "check" }; }
        public static ButtonModelView btnDelete(string nombre = "", string attr = "")
        { return new ButtonModelView() { name = "Eliminar " + nombre, attribute = "button " + attr, isEnabled = true, icon = "delete_forever" }; }
        public static ButtonModelView btnNew(string nombre = "", string attr = "")
        { return new ButtonModelView() { name = "Agregar " + nombre, attribute = "button " + attr, isEnabled = true, icon = "add_circle_outline" }; }
        public static ButtonModelView btnEdit(string nombre = "", string attr = "")
        { return new ButtonModelView() { name = "Editar " + nombre, attribute = "button " + attr, isEnabled = true, icon = "edit" }; }
        public static ButtonModelView btnActivate(string nombre = "", string attr = "")
        { return new ButtonModelView() { name = "Activar " + nombre, attribute = "button " + attr, isEnabled = true, icon = "unarchive" }; }
        public static ButtonModelView btnNext(string nombre = "", string attr = "")
        { return new ButtonModelView() { name = "Siguiente " + nombre, attribute = "button " + attr, isEnabled = true, icon = "arrow_forward" }; }
        public static ButtonModelView btnPrevious(string nombre = "", string attr = "")
        { return new ButtonModelView() { name = "Anterior " + nombre, attribute = "button " + attr, isEnabled = false, icon = "arrow_back" }; }
        public static ButtonModelView btnCustom(string nombre = "", string attr = "",bool enabled=true,string ico="")
        { return new ButtonModelView() { name = nombre, attribute = attr, isEnabled = enabled, icon = ico }; }
    }

}
