namespace TaskManager.Localization.Languages
{
    class English_US : ILanguage
    {
        public string OK { get { return "OK"; } }
        public string Cancel { get { return "Cancel"; } }
        public string Warning { get { return "Warning"; } }

        public string Application_ErrorUnrecoverable { get { return "An unrecoverable exception occured"; } }
        public string Application_Shutdown { get { return "The application will now shut down"; } }
        public string Application_FataErrorTitle { get { return "FATAL ERROR!"; } }

        public string AddTask_DefaultTitle { get { return "(title)"; } }
        public string AddTask_DefaultDescription { get { return "(description)"; } }
        public string AddTask_UserAssignedLabel { get { return "Assigned To"; } }
        public string AddTask_PriorityLabel { get { return "Priority"; } }
        public string AddTask_DueDateLabel { get { return "Due Date"; } }
        public string AddTask_Title { get { return "Add Task"; } }
        public string AddTask_MissingUserValue { get { return "An assigned user must be selected."; } }

        public string CommentControl_UserNameLabel { get { return "User: "; } }
        public string CommentControl_DateLabel { get { return "Date: "; } }

        public string Login_Failed { get { return "Login Failed: unrecognized username or password."; } }
        public string Login_FailedTitle { get { return "Access Denied"; } }
        public string Login_UserNameLabel { get { return "User Name"; } }
        public string Login_SaveUserLabel { get { return "Save User Name"; } }
        public string Login_PasswordLabel { get { return "Password"; } }
        public string Login_Title { get { return "Login"; } }
        public string Login_DataSource { get { return "Data Source"; } }
        public string Login_Local { get { return "Local"; } }
        public string Login_Server { get { return "Server"; } }

        public string Main_PriorityLabel { get { return "Priority"; } }
        public string Main_ProgressLabel { get { return "Progress"; } }
        public string Main_SearchTagsLabel { get { return "Search By Tags"; } }
        public string Main_FilterUserLabel { get { return "Filter By Assigned User"; } }
        public string Main_CreatorLabel { get { return "Creator: "; } }
        public string Main_Creator { get { return "(creator)"; } }
        public string Main_UserAssignedLabel { get { return "Assigned To: "; } }
        public string Main_DueDateLabel { get { return "Due Date: "; } }
        public string Main_ClearCommentButton { get { return "Clear"; } }
        public string Main_AddCommentButton { get { return "Add"; } }
        public string Main_AddCommentLabel { get { return "Add Comment"; } }
        public string Main_TaskIDHeader { get { return "#"; } }
        public string Main_PriorityHeader { get { return "P"; } }
        public string Main_TitleHeader { get { return "Title"; } }
        public string Main_DateCreatedHeader { get { return "Created"; } }
        public string Main_MenuFile { get { return "&File"; } }
        public string Main_MenuLogin { get { return "&Login..."; } }
        public string Main_MenuLogout { get { return "L&ogout"; } }
        public string Main_MenuEditUserDetails { get { return "Edit &User Details"; } }
        public string Main_MenuImport { get { return "&Import"; } }
        public string Main_MenuExport { get { return "&Export"; } }
        public string Main_MenuExit { get { return "E&xit"; } }
        public string Main_MenuEdit { get { return "&Edit"; } }
        public string Main_MenuAddTask { get { return "&Add Task"; } }
        public string Main_MenuManageTags { get { return "&Manage Tags"; } }
        public string Main_MenuLanguage { get { return "Language"; } }
        public string Main_MenuAttachFile { get { return "Attach &File..."; } }
        public string Main_Title { get { return "Task Tracker"; } }
        public string Main_MenuHelp { get { return "Help"; } }
        public string Main_Due { get { return "Due"; } }

        public string TagManager_Title { get { return "Tag Manager"; } }
        public string TagManager_NameHeader { get { return "Name"; } }
        public string TagManager_DescriptionHeader { get { return "Description"; } }
        public string TagManager_ChkDefaultLabel { get { return "Checked: tag is selected by default"; } }

        public string UpdateUser_ErrorPassword { get { return "Passwords do not match"; } }
        public string UpdateUser_Instructions { get { return "Update User Settings for User"; } }
        public string UpdateUser_UserName { get { return "(username)"; } }
        public string UpdateUser_EmailLabel { get { return "Email"; } }
        public string UpdateUser_PasswordLabel { get { return "New Password"; } }
        public string UpdateUser_PasswordConfirmLabel { get { return "Confirm Password"; } }
        public string UpdateUser_Title { get { return "Update User"; } }
    }
}