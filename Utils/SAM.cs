namespace CoordinateTrackerAndClicker.Utils
{
    internal static class SAM // String Archive Messages
    {
        //----------------------------------- FORM 2 MESSAGES ---------------------------------------------------------
        public readonly static string START_BUTTON_OK = nameof(START_BUTTON_OK);
        public readonly static string STOP_BUTTON_NO_RECORD = nameof(STOP_BUTTON_NO_RECORD);
        public readonly static string STOP_BUTTON_OK_RECORD = nameof(STOP_BUTTON_OK_RECORD);
        public readonly static string ON_GLOBAL_MOUSE_CLICK = nameof(ON_GLOBAL_MOUSE_CLICK);
        public readonly static string BTN_ADD_ACTION_NO_RECORD = nameof(BTN_ADD_ACTION_NO_RECORD);
        public readonly static string BTN_ADD_ACTION_OK = nameof(BTN_ADD_ACTION_OK);
        public readonly static string BTN_CREATE_MACRO_OK = nameof(BTN_CREATE_MACRO_OK);
        public readonly static string LST_AVEILABLE_MACROS_FULL = nameof(LST_AVEILABLE_MACROS_FULL);
        public readonly static string BTN_EXECUTE_MACRO_START = nameof(BTN_EXECUTE_MACRO_START);
        public readonly static string BTN_EXECUTE_MACRO_MISSING_MACRO = nameof(BTN_EXECUTE_MACRO_MISSING_MACRO);
        public readonly static string BTN_EXECUTE_MACRO_FINISH = nameof(BTN_EXECUTE_MACRO_FINISH);
        public readonly static string BTN_STOP_MACRO = nameof(BTN_STOP_MACRO);
        public readonly static string BTN_ACTION_DELETE_OK_REMOVE = nameof(BTN_ACTION_DELETE_OK_REMOVE);
        public readonly static string BTN_MACRO_FOR_EXECUTE_DELETE_OK_REMOVE = nameof(BTN_MACRO_FOR_EXECUTE_DELETE_OK_REMOVE);
        public readonly static string CHK_ALL_MACROS_TO_EXECUTE_ALL = nameof(CHK_ALL_MACROS_TO_EXECUTE_ALL);
        public readonly static string CHK_ALL_MACROS_TO_EXECUTE_SINGLE = nameof(CHK_ALL_MACROS_TO_EXECUTE_SINGLE);
        public readonly static string IS_NAME_INVALID = nameof(IS_NAME_INVALID);
        public readonly static string IS_LIST_EMPTY = nameof(IS_LIST_EMPTY);
        public readonly static string IS_NOTING_SELECTED_IN_LIST = nameof(IS_NOTING_SELECTED_IN_LIST);
        public readonly static string INITIALIZE_BUTTONS_BEHAVIOR_ERROR = nameof(INITIALIZE_BUTTONS_BEHAVIOR_ERROR);
        public readonly static string LOAD_SAVED_MACROS_BASE_DIRECTORY = nameof(LOAD_SAVED_MACROS_BASE_DIRECTORY);
        public readonly static string LOAD_SAVED_MACROS_PATH_TO_SAVE = nameof(LOAD_SAVED_MACROS_PATH_TO_SAVE);
        public readonly static string LOAD_SAVED_MACROS_LOADING = nameof(LOAD_SAVED_MACROS_LOADING);
        public readonly static string LOAD_SAVED_MACROS_LOADED = nameof(LOAD_SAVED_MACROS_LOADED);
        public readonly static string LOAD_SAVED_MACROS_LIST_EMPTY = nameof(LOAD_SAVED_MACROS_LIST_EMPTY);
        public readonly static string BTN_MACRO_SAVE_TO_DB_NO_SELECTED = nameof(BTN_MACRO_SAVE_TO_DB_NO_SELECTED);
        public readonly static string BTN_MACRO_SAVE_TO_DB_ERROR_DIR_OR_FILE = nameof(BTN_MACRO_SAVE_TO_DB_ERROR_DIR_OR_FILE);
        public readonly static string BTN_MACRO_SAVE_TO_DB_OK = nameof(BTN_MACRO_SAVE_TO_DB_OK);
        public readonly static string BTN_MACRO_SAVE_TO_DB_M_EXISTS_OR_ERROR = nameof(BTN_MACRO_SAVE_TO_DB_M_EXISTS_OR_ERROR);
        public readonly static string BTN_MACRO_DELETE_FROM_DB_NO_SELECTED = nameof(BTN_MACRO_DELETE_FROM_DB_NO_SELECTED);
        public readonly static string BTN_MACRO_DELETE_FROM_DB_ERROR_DIR_OR_FILE = nameof(BTN_MACRO_DELETE_FROM_DB_ERROR_DIR_OR_FILE);
        public readonly static string BTN_MACRO_DELETE_FROM_DB_ERROR_REQUEST = nameof(BTN_MACRO_DELETE_FROM_DB_ERROR_REQUEST);
        public readonly static string BTN_MACRO_DELETE_FROM_DB_OK = nameof(BTN_MACRO_DELETE_FROM_DB_OK);

        //------------------------------------------ MACRO SERVICE MESSAGES --------------------------------------
        public readonly static string CREATE_MACRO_NAME_EXIST = nameof(CREATE_MACRO_NAME_EXIST);
        public readonly static string EXECUTE_MACRO_ASYNC_REPETITIONS = nameof(EXECUTE_MACRO_ASYNC_REPETITIONS);
        public readonly static string EXECUTE_MACRO_ASYNC_DURATION = nameof(EXECUTE_MACRO_ASYNC_DURATION);
        public readonly static string EXECUTE_MACRO_ASYNC_EXPECTED_DURATION = nameof(EXECUTE_MACRO_ASYNC_EXPECTED_DURATION);
        public readonly static string EXECUTE_MACRO_ASYNC_REPETITION = nameof(EXECUTE_MACRO_ASYNC_REPETITION);
        public readonly static string EXECUTE_MACRO_ASYNC_STARTED = nameof(EXECUTE_MACRO_ASYNC_STARTED);
        public readonly static string EXECUTE_MACRO_ASYNC_MACRO_REPETITION = nameof(EXECUTE_MACRO_ASYNC_MACRO_REPETITION);
        public readonly static string EXECUTE_MACRO_ASYNC_ACTION_STARTED = nameof(EXECUTE_MACRO_ASYNC_ACTION_STARTED);
        public readonly static string EXECUTE_MACRO_ASYNC_ACTION_REPETITION = nameof(EXECUTE_MACRO_ASYNC_ACTION_REPETITION);
        public readonly static string EXECUTE_MACRO_ASYNC_REMAIN_TIME = nameof(EXECUTE_MACRO_ASYNC_REMAIN_TIME);
        public readonly static string EXECUTE_MACRO_ASYNC_END_AFTER = nameof(EXECUTE_MACRO_ASYNC_END_AFTER);
        public readonly static string EXECUTE_MACRO_ASYNC_ACTION_PROGRESS = nameof(EXECUTE_MACRO_ASYNC_ACTION_PROGRESS);
        public readonly static string EXECUTE_MACRO_ASYNC_MACRO_PROGRESS = nameof(EXECUTE_MACRO_ASYNC_MACRO_PROGRESS);
        public readonly static string EXECUTE_MACRO_ASYNC_MACRO_COMPLETED = nameof(EXECUTE_MACRO_ASYNC_MACRO_COMPLETED);
        public readonly static string EXECUTE_MACRO_ASYNC_MACRO_INTERRUPTED = nameof(EXECUTE_MACRO_ASYNC_MACRO_INTERRUPTED);

        //------------------------------------- JSON DATA STORAGE MANUAL SELECT ----------------------------------
        public readonly static string SET_SAVE_DIRECTORY = nameof(SET_SAVE_DIRECTORY);

        //------------------------------------------ BUTTON HANDLER ---------------------------------------------
        public readonly static string ADD_NEW_BUTTON_ERROR = nameof(ADD_NEW_BUTTON_ERROR);
        public readonly static string CLICK_BUTTON_MECHANICS_EXECUTE_ERROR = nameof(CLICK_BUTTON_MECHANICS_EXECUTE_ERROR);
        public readonly static string CHECK_FOR_NULL = nameof(CHECK_FOR_NULL);

        //------------------------------------------ PRINT TEXT -------------------------------------------------
        public readonly static string DISPLAY_ACTION_INFO_CORDINATES = nameof(DISPLAY_ACTION_INFO_CORDINATES);
        public readonly static string DISPLAY_ACTION_INFO_ACTION = nameof(DISPLAY_ACTION_INFO_ACTION);
        public readonly static string DISPLAY_ACTION_INFO_BEFORE = nameof(DISPLAY_ACTION_INFO_BEFORE);
        public readonly static string DISPLAY_ACTION_INFO_AFTER = nameof(DISPLAY_ACTION_INFO_AFTER);
        public readonly static string DISPLAY_ACTION_INFO_FREQUENCY = nameof(DISPLAY_ACTION_INFO_FREQUENCY);
        public readonly static string DISPLAY_ACTION_INFO_ORIGINAL_POSITION = nameof(DISPLAY_ACTION_INFO_ORIGINAL_POSITION);
        public readonly static string DISPLAY_MACRO_INFO = nameof(DISPLAY_MACRO_INFO);


    }
}
