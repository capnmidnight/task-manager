namespace TaskManager.Localization
{
    public interface ILanguage
    {
        string OK { get;}
        string Cancel { get;}
        string Warning { get;}

        string Application_ErrorUnrecoverable { get;}
        string Application_Shutdown { get;}
        string Application_FataErrorTitle { get;}

        string AddTask_DefaultTitle { get;}
        string AddTask_DefaultDescription { get;}
        string AddTask_UserAssignedLabel { get;}
        string AddTask_PriorityLabel { get;}
        string AddTask_DueDateLabel { get;}
        string AddTask_Title { get;}
        string AddTask_MissingUserValue { get;}

        string CommentControl_UserNameLabel { get;}
        string CommentControl_DateLabel { get;}

        string Login_FailedTitle { get;}
        string Login_Failed { get;}
        string Login_UserNameLabel { get;}
        string Login_PasswordLabel { get;}
        string Login_SaveUserLabel { get;}
        string Login_Title { get;}
        string Login_DataSource { get;}
        string Login_Local { get;}
        string Login_Server { get;}

        string Main_SearchTagsLabel { get;}
        string Main_FilterUserLabel { get;}
        string Main_CreatorLabel { get;}
        string Main_Creator { get;}
        string Main_UserAssignedLabel { get;}
        string Main_DueDateLabel { get;}
        string Main_ClearCommentButton { get;}
        string Main_AddCommentButton { get;}
        string Main_AddCommentLabel { get;}
        string Main_TaskIDHeader { get;}
        string Main_PriorityHeader { get;}
        string Main_TitleHeader { get;}
        string Main_DateCreatedHeader { get;}
        string Main_MenuFile { get;}
        string Main_MenuLogin { get;}
        string Main_MenuLogout { get;}
        string Main_MenuEditUserDetails { get;}
        string Main_MenuExit { get;}
        string Main_MenuImport { get;}
        string Main_MenuExport { get;}
        string Main_MenuEdit { get;}
        string Main_MenuAddTask { get;}
        string Main_MenuManageTags { get;}
        string Main_MenuLanguage { get;}
        string Main_Title { get;}
        string Main_PriorityLabel { get;}
        string Main_ProgressLabel { get;}
        string Main_MenuAttachFile { get;}
        string Main_MenuHelp { get; }
        string Main_Due { get; }

        string TagManager_Title { get;}
        string TagManager_NameHeader { get;}
        string TagManager_DescriptionHeader { get;}
        string TagManager_ChkDefaultLabel { get;}

        string UpdateUser_ErrorPassword { get;}
        string UpdateUser_Instructions { get;}
        string UpdateUser_UserName { get;}
        string UpdateUser_EmailLabel { get;}
        string UpdateUser_PasswordLabel { get;}
        string UpdateUser_PasswordConfirmLabel { get;}
        string UpdateUser_Title { get;}
    }
}
