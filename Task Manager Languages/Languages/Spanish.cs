namespace TaskManager.Localization.Languages
{
    class Spanish : ILanguage
    {
        public string OK { get { return "OK"; } }
        public string Cancel { get { return "Cancelar"; } }
        public string Warning { get { return "Advertencia"; } }

        public string Application_ErrorUnrecoverable { get { return "Una excepción ocurrió irrecuperable"; } }
        public string Application_Shutdown { get { return "La aplicación ahora cerrado"; } }
        public string Application_FataErrorTitle { get { return "ERROR FATAL!"; } }

        public string AddTask_DefaultTitle { get { return "{título}"; } }
        public string AddTask_DefaultDescription { get { return "{descripción}"; } }
        public string AddTask_UserAssignedLabel { get { return "Asignado a"; } }
        public string AddTask_PriorityLabel { get { return "prioridad"; } }
        public string AddTask_DueDateLabel { get { return "Fecha de Vencimiento"; } }
        public string AddTask_Title { get { return "Añadir Tarea"; } }
        public string AddTask_MissingUserValue { get { return "Asignado un usuario debe ser seleccionado."; } }

        public string CommentControl_UserNameLabel { get { return "Usuario:"; } }
        public string CommentControl_DateLabel { get { return "Fecha:"; } }

        public string Login_Failed { get { return "Error de inicio de sesión: no reconocido nombre de usuario o contraseña"; } }
        public string Login_FailedTitle { get { return "Acceso denegado"; } }
        public string Login_UserNameLabel { get { return "Nombre de Usuario"; } }
        public string Login_SaveUserLabel { get { return "Guardar nombre de usuario"; } }
        public string Login_PasswordLabel { get { return "Contraseña"; } }
        public string Login_Title { get { return "Usuario"; } }
        public string Login_DataSource { get { return "Fuente de Datos"; } }
        public string Login_Local { get { return "Local"; } }
        public string Login_Server { get { return "Servidor"; } }

        public string Main_PriorityLabel { get { return "Prioridad"; } }
        public string Main_ProgressLabel { get { return "Progreso"; } }
        public string Main_SearchTagsLabel { get { return "Buscar por etiquetas"; } }
        public string Main_FilterUserLabel { get { return "Filtrar por Asignación de Usuario"; } }
        public string Main_CreatorLabel { get { return "Creador:"; } }
        public string Main_Creator { get { return "{creador}"; } }
        public string Main_UserAssignedLabel { get { return "Asignado a:"; } }
        public string Main_DueDateLabel { get { return "Fecha de Vencimiento:"; } }
        public string Main_ClearCommentButton { get { return "Borrar"; } }
        public string Main_AddCommentButton { get { return "Añadir"; } }
        public string Main_AddCommentLabel { get { return "Añadir comentario"; } }
        public string Main_TaskIDHeader { get { return "#"; } }
        public string Main_PriorityHeader { get { return "P"; } }
        public string Main_TitleHeader { get { return "Título"; } }
        public string Main_DateCreatedHeader { get { return "Creado"; } }
        public string Main_MenuFile { get { return "&Archivo"; } }
        public string Main_MenuLogin { get { return "&Usuario ..."; } }
        public string Main_MenuLogout { get { return "&Cerrar sesión"; } }
        public string Main_MenuEditUserDetails { get { return "Editar detalles y del Usuario"; } }
        public string Main_MenuImport { get { return "&Importar"; } }
        public string Main_MenuExport { get { return "&Exporta"; } }
        public string Main_MenuExit { get { return "&Salir"; } }
        public string Main_MenuEdit { get { return "&Editar"; } }
        public string Main_MenuAddTask { get { return "&Añadir Tarea"; } }
        public string Main_MenuManageTags { get { return "Administrar y etiquetas"; } }
        public string Main_MenuLanguage { get { return "Lengua"; } }
        public string Main_MenuHelp { get { return "Ayuda"; } }
        public string Main_MenuAttachFile { get { return "&Adjuntar Archivos..."; } }
        public string Main_Due { get { return "Debido"; } }
        public string Main_Title { get { return "de seguimiento"; } }

        public string TagManager_Title { get { return "Etiqueta Manager"; } }
        public string TagManager_NameHeader { get { return "Nombre"; } }
        public string TagManager_DescriptionHeader { get { return "Descripción"; } }
        public string TagManager_ChkDefaultLabel { get { return "Selección: tag es seleccionado por defecto"; } }

        public string UpdateUser_ErrorPassword { get { return "Las contraseñas no coinciden"; } }
        public string UpdateUser_Instructions { get { return "Actualización del usuario para el usuario"; } }
        public string UpdateUser_UserName { get { return "{nombre de usuario}"; } }
        public string UpdateUser_EmailLabel { get { return "Correo electrónico"; } }
        public string UpdateUser_PasswordLabel { get { return "Nueva Contraseña"; } }
        public string UpdateUser_PasswordConfirmLabel { get { return "Confirmar Contraseña"; } }
        public string UpdateUser_Title { get { return "Actualizar Usuario"; } }
    }
}