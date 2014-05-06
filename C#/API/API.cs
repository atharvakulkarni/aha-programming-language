﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aha.Base;
using Aha.Core;

namespace Aha.API
{
    namespace Jobs
    //doc 
    //    Title: "Jobs"
    //    Purpose: "Basic jobs"
    //    Package: "Application Program Interface"
    //    Author: "Roman Movchan, Melbourne, Australia"
    //    Created: "2013-09-05"
    //end

    //type Event: arbitrary "custom event type"
    //use Time: Base/Time
    //export Types:
    //    type Job: opaque "a job for runtime environment"
    //    type Behavior: obj [Job] handle(Event) end "event loop"
    //    type Engine:
    //        [
    //            raise: { Event -> Job } "raise event to be immediately handled"
    //            compute: { [ event: { -> Event } fail: Event ] -> Job } "job that computes an event in the background and raises it"
    //            enquireTime: { { @Time!Timestamp -> Event } -> Job } "job that raises event that receives current system time"
    //            delay: { @Time!Interval, Job -> Job } "do job after delay"
    //            schedule: { @Time!Timestamp, Job -> Job } "do job at specific time"
    //            stop: Job "terminate all current jobs"
    //        ] "interface to the job engine"
    //end
    {
        public class opaque_Job<tpar_Event>
        {
            public delegate void Execute();

            public string title;
            public Execute execute;
        }

        public interface iobj_Behavior<tpar_Event> : IahaObject<IahaArray<opaque_Job<tpar_Event>>>
        {
            void action_handle(tpar_Event param_event);
        }

        public delegate tpar_Event func_EnquireTime<tpar_Event>(Aha.Base.Time.opaque_Timestamp time);

        public interface icomp_ComputeParams<tpar_Event>
        {
            tpar_Event fattr_event();
            tpar_Event attr_fail();
        }

        public interface icomp_Engine<tpar_Event>
        {
            //opaque_Job<tpar_Event> fattr_run(opaque_Job<tpar_Event> job);
            opaque_Job<tpar_Event> fattr_raise(tpar_Event e);
            opaque_Job<tpar_Event> fattr_delay(Aha.Base.Time.opaque_Interval interval, tpar_Event e);
            opaque_Job<tpar_Event> fattr_schedule(Aha.Base.Time.opaque_Timestamp time, tpar_Event e);
            opaque_Job<tpar_Event> fattr_enquireTime(func_EnquireTime<tpar_Event> enq);
            opaque_Job<tpar_Event> fattr_compute(icomp_ComputeParams<tpar_Event> param);
            opaque_Job<tpar_Event> attr_stop();
        }
    }

    namespace Environment
    //doc 
    //    Title: "Environment"
    //    Purpose: "Static information on the runtime environment"
    //    Package: "Application Program Interface"
    //    Author: "Roman Movchan, Melbourne, Australia"
    //    Created: "2013-08-22"
    //end

//type String: [character] "alias for character array type"

//use Format: Base/Formatting
    //use StrUtils: Base/StrUtils
    //use Time: Base/Time
    //use Money: Base/Money
    //use Float: Base/Float

//export Types:
    //    type FilePath: opaque "file path"
    //    type DirPath: opaque "directory (folder) path"
    //end

//export Info:    
    //    the Framework:
    //        [
    //            name: String "framework name"
    //            version:
    //                [
    //                    major: integer
    //                    minor: integer
    //                    build: integer
    //                ] "framework version"
    //            components: [String] "classnames of all registered components"
    //        ] "runtime framework info"
    //    the Platform: 
    //        [
    //            Windows: [ win32: win64: ] " Windows (32- or 64-bit)" 
    //            MacOSX: "Mac OSX" 
    //            Linux: "Linux" 
    //            FreeBSD: "FreeBSD" 
    //            iOS: "iOS" 
    //            Android: "Android" 
    //            other: "other"
    //        ] "platform kind"
    //    the Locale:
    //        [
    //            GMToffset: @Time!Interval "GMT offset"
    //            country: String "country name"
    //            language: String "language"
    //            currency: String "currency symbol(s)"
    //            decimal: character "decimal separator"
    //            format: @Format!Format "formatting routines"
    //            deformat: @Format!Deformat "deformatting routines"
    //            charCompare: @StrUtils!CharCompare "character comparison function"
    //            upper: { character -> character } "upper case conversion"
    //            lower: { character -> character } "lower case conversion"
    //        ] "locale info"
    //    the FileSystem: 
    //        [
    //            eol: String "end-of-line characters"
    //            splitLines: { character* -> String* } "convert sequence of chars to sequence of lines"
    //            joinLines: { String* -> character* } "convert sequence of lines to sequence of chars"
    //            filePath: { DirPath, String -> FilePath } "get file path from file name and directory path"
    //            subDirPath: { DirPath, String -> DirPath } "get subdirectory path from its name and parent directory path"
    //            parentDirPath: { DirPath -> DirPath } "get parent directory path"
    //            fileName: { FilePath -> String } "get file name (with extension) from file path"
    //            fileDir: { FilePath -> DirPath } "get file's directory path"
    //            fileExt: { FilePath -> String } "extract file's extension (empty string if none)"
    //            changeExt: { FilePath, String -> FilePath } "change file's extension"
    //            splitDirPath: { DirPath -> [String] } "split directory path into string components"
    //            buildDirPath: { [String] -> DirPath } "build directory path from string components"
    //            workingDir: DirPath "directory where application can write data"
    //            appDir: DirPath "directory from which application has started"
    //            rootDir: DirPath "file system's root directory"
    //        ] "file system info and path handling routines"
    //    the Username: String "user name"
    //    the SystemID: String "system identification"
    //    the Variables: [[ name: String value: String ]] "list of all environment variables and their values"
    //end
    //export Operators:
    //    (~str integer): { integer -> String } "convert integer to string"
    //    (~str @Float!Float): { @Float!Float -> String } "convert Float to string (local format)"
    //    (~str @Time!Timestamp): { @Time!Timestamp -> String } "convert Timestamp to string (local format)"
    //    (~str @Money!Money): { @Money!Money -> String } "convert Money to string (local format)"
    //    (~int String): { String -> integer } "convert string to integer"
    //    (~float String): { String -> @Float!Float } "convert string (local format) to Float"
    //    (~date String): { String -> @Time!Timestamp } "convert string (local format) to date"
    //    (~time String): { String -> @Time!Interval } "convert string (local format) to time"
    //    (~timestamp String): { String -> @Time!Timestamp } "convert string (local format) to timestamp"
    //    (~money String): { String -> @Money!Money } "convert string (local format) to Money"
    //    (String <= String): { String, String } "compare string in local sorting order"
    //    (String < String): { String, String } "compare string in local sorting order"
    //    (String > String): { String, String } "compare string in local sorting order"
    //    (String >= String): { String, String } "compare string in local sorting order"
    //    (FilePath = FilePath): { FilePath, FilePath } "are paths the same?"
    //    (DirPath = DirPath): { DirPath, DirPath } "are paths the same?"
    //end    
    {
        public struct opaque_FilePath
        {
            public string value;
        }

        public struct opaque_DirPath
        {
            public string value;
        }

        public interface icomp_Version
        {
            Int64 attr_major();
            Int64 attr_minor();
            Int64 attr_build();
        }

        public interface icomp_Framework
        {
            IahaArray<char> attr_name();
            icomp_Version attr_version();
            IahaArray<IahaArray<char>> attr_components();
        }

        public interface icomp_Platform
        {
            bool attr1_Windows();
            bool attr2_MacOSX();
            bool attr3_Linux();
            bool attr4_FreeBSD();
            bool attr5_iOS();
            bool attr6_Android();
            bool attr7_other();
        }

        public interface icomp_Locale
        {
            Aha.Base.Time.opaque_Interval attr_GMToffset();
            IahaArray<char> attr_country();
            IahaArray<char> attr_language();
            IahaArray<char> attr_currency();
            char attr_decimal();
            //format: @Format!Format "formatting routines"
            //deformat: @Format!Deformat "deformatting routines"
            //charCompare: @StrUtils!CharCompare "character comparison function"
            IahaArray<char> fattr_upper(IahaArray<char> ch);
            IahaArray<char> fattr_lower(IahaArray<char> ch);
            bool fattr_sameText(IahaArray<char> param_first, IahaArray<char> param_second);
        }

        public interface icomp_FileSystem
        {
            IahaArray<char> attr_eol();
            //splitLines: { character* -> String* } "convert sequence of chars to sequence of lines"
            //joinLines: { String* -> character* } "convert sequence of lines to sequence of chars"
            opaque_FilePath fattr_filePath(opaque_DirPath param_dir, IahaArray<char> param_name);
            opaque_DirPath fattr_subDirPath(opaque_DirPath param_dir, IahaArray<char> param_name);
            opaque_DirPath fattr_parentDirPath(opaque_DirPath param_dir);
            IahaArray<char> fattr_fileName(opaque_FilePath param_path);
            opaque_DirPath fattr_fileDir(opaque_FilePath param_dir);
            IahaArray<char> fattr_fileExt(opaque_FilePath param_path);
            opaque_FilePath fattr_changeExt(opaque_FilePath param_dir, IahaArray<char> param_ext);
            IahaArray<IahaArray<char>> fattr_splitDirPath(opaque_DirPath param_path);
            opaque_DirPath fattr_buildDirPath(IahaArray<IahaArray<char>> param_parts);
            opaque_DirPath fattr_workingDir();
            opaque_DirPath fattr_appDir();
            opaque_DirPath fattr_rootDir();
        }

        public interface imod_Environment
        {
            icomp_Framework attr_Framework();
            icomp_Platform attr_Platform();
            icomp_FileSystem attr_FileSystem();
        }

        public class module_Environment : AhaModule, imod_Environment
        {
            struct comp_Version : icomp_Version
            {
                public Int64 attr_major() { return 0; }
                public Int64 attr_minor() { return 1; }
                public Int64 attr_build() { return 1; }
            }

            struct comp_Framework : icomp_Framework
            {
                public IahaArray<char> attr_name() { return new AhaString("Aha! for .NET"); }
                public icomp_Version attr_version() { return new comp_Version(); }
                public IahaArray<IahaArray<char>> attr_components() { return new AhaArray<IahaArray<char>>(new IahaArray<char>[] { }); }
            }

            public icomp_Framework attr_Framework() { return new comp_Framework(); }

            struct comp_Platform : icomp_Platform
            {
                public bool attr1_Windows() { return true; }
                public bool attr2_MacOSX() { return false; }
                public bool attr3_Linux() { return false; }
                public bool attr4_FreeBSD() { return false; }
                public bool attr5_iOS() { return false; }
                public bool attr6_Android() { return false; }
                public bool attr7_other() { return false; }
            }

            public icomp_Platform attr_Platform() { return new comp_Platform(); }

            class comp_Locale : icomp_Locale
            {
                private Aha.Base.Time.opaque_Interval field_GMToffset = new Aha.Base.Time.opaque_Interval { ticks = DateTime.Now.Ticks - DateTime.Now.ToUniversalTime().Ticks };
                public Aha.Base.Time.opaque_Interval attr_GMToffset() { return field_GMToffset; }
                public IahaArray<char> attr_country() { return new AhaString(System.Globalization.CultureInfo.CurrentCulture.EnglishName); }
                public IahaArray<char> attr_language() { return new AhaString(System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName); }
                public IahaArray<char> attr_currency() { return new AhaString(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol); }
                public char attr_decimal() { return System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]; }
                //format: @Format!Format "formatting routines"
                //deformat: @Format!Deformat "deformatting routines"
                //charCompare: @StrUtils!CharCompare "character comparison function"
                public IahaArray<char> fattr_upper(IahaArray<char> param_str) { return new AhaString((new string(param_str.get())).ToUpper(System.Globalization.CultureInfo.CurrentCulture)); }
                public IahaArray<char> fattr_lower(IahaArray<char> param_str) { return new AhaString((new string(param_str.get())).ToLower(System.Globalization.CultureInfo.CurrentCulture)); }
                public bool fattr_sameText(IahaArray<char> param_first, IahaArray<char> param_second)
                {
                    return String.Compare(
                        new string(param_first.get()),
                        new string(param_second.get()),
                        StringComparison.CurrentCultureIgnoreCase) == 0;
                }
            }

            public icomp_Locale attr_Locale() { return new comp_Locale(); }

            class comp_FileSystem : icomp_FileSystem
            {
                public IahaArray<char> attr_eol() { return new AhaString("\r\n"); }
                //splitLines: { character* -> String* } "convert sequence of chars to sequence of lines"
                //joinLines: { String* -> character* } "convert sequence of lines to sequence of chars"
                public opaque_FilePath fattr_filePath(opaque_DirPath param_dir, IahaArray<char> param_name)
                { return new opaque_FilePath { value = param_dir.value + System.IO.Path.PathSeparator + (new string(param_name.get())) }; }
                public opaque_DirPath fattr_subDirPath(opaque_DirPath param_dir, IahaArray<char> param_name)
                { return new opaque_DirPath { value = param_dir.value + System.IO.Path.PathSeparator + (new string(param_name.get())) }; }
                public opaque_DirPath fattr_parentDirPath(opaque_DirPath param_dir)
                { return new opaque_DirPath { value = System.IO.Path.GetDirectoryName(param_dir.value) }; }
                public IahaArray<char> fattr_fileName(opaque_FilePath param_path)
                { return new AhaString(System.IO.Path.GetFileName(param_path.value)); }
                public opaque_DirPath fattr_fileDir(opaque_FilePath param_path)
                { return new opaque_DirPath { value = System.IO.Path.GetDirectoryName(param_path.value) }; }
                public IahaArray<char> fattr_fileExt(opaque_FilePath param_path)
                { return new AhaString(System.IO.Path.GetExtension(param_path.value)); }
                public opaque_FilePath fattr_changeExt(opaque_FilePath param_dir, IahaArray<char> param_ext)
                { return new opaque_FilePath { value = System.IO.Path.ChangeExtension(param_dir.value, new string(param_ext.get())) }; }
                public IahaArray<IahaArray<char>> fattr_splitDirPath(opaque_DirPath param_path)
                {
                    List<int> list = new List<int>();
                    int j = 0;
                    while (j != -1)
                    {
                        j = param_path.value.IndexOf(System.IO.Path.PathSeparator, j, param_path.value.Length);
                        if (j == -1) break;
                        list.Add(j);
                        j++;
                    }
                    IahaArray<char>[] temp = new IahaArray<char>[list.Count + 1];
                    j = 0;
                    char[] seg;
                    for (int i = 0; i < temp.Length; i++)
                    {
                        seg = new char[list[i] - j];
                        Array.Copy(param_path.value.ToCharArray(), j, seg, 0, list[i] - j);
                        temp[i] = new AhaString(seg);
                        j = list[i] + 1;

                    }
                    seg = new char[param_path.value.Length - j];
                    Array.Copy(param_path.value.ToCharArray(), j, seg, 0, param_path.value.Length - j);
                    temp[list.Count] = new AhaString(seg);
                    return new AhaArray<IahaArray<char>>(temp);
                }
                public opaque_DirPath fattr_buildDirPath(IahaArray<IahaArray<char>> param_parts)
                {
                    string[] paths = new string[param_parts.size()];
                    for (int i = 0; i < param_parts.size(); i++) paths[i] = new string(param_parts.at(i).get());
                    return new opaque_DirPath { value = System.IO.Path.Combine(paths) };
                }
                public opaque_DirPath fattr_workingDir() { return new opaque_DirPath { value = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) }; }
                public opaque_DirPath fattr_appDir() { return new opaque_DirPath { value = System.Reflection.Assembly.GetEntryAssembly().Location }; }
                public opaque_DirPath fattr_rootDir() { return new opaque_DirPath { value = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) }; }
            }

            public icomp_FileSystem attr_FileSystem() { return new comp_FileSystem(); }

            //    (~str integer): { integer -> String } "convert integer to string"
            public IahaArray<char> op__str_integer(Int64 param_int) { return new AhaString(param_int.ToString()); }
            //    (~str @Float!Float): { @Float!Float -> String } "convert Float to string (local format)"
            public IahaArray<char> op__str_Float(Aha.Base.Math.opaque_Float param_float) { return new AhaString(param_float.value.ToString()); }
            //    (~str @Time!Timestamp): { @Time!Timestamp -> String } "convert Timestamp to string (local format)"
            public IahaArray<char> op__str_Timestamp(Aha.Base.Time.opaque_Timestamp param_timestamp) { DateTime dt = new DateTime(param_timestamp.ticks); return new AhaString(dt.ToString()); }
            //    (~str @Money!Money): { @Money!Money -> String } "convert Money to string (local format)"
            //    (~int String): { String -> integer } "convert string to integer"
            public Int64 op__int_String(IahaArray<char> param_str) { return Convert.ToInt64(new string(param_str.get())); }
            //    (~float String): { String -> @Float!Float } "convert string (local format) to Float"
            public Aha.Base.Math.opaque_Float op__float_String(IahaArray<char> param_str) { return new Aha.Base.Math.opaque_Float() { value = Convert.ToDouble(new string(param_str.get())) }; }
            //    (~date String): { String -> @Time!Timestamp } "convert string (local format) to date"
            public Aha.Base.Time.opaque_Timestamp op__date_String(IahaArray<char> param_str) { return new Aha.Base.Time.opaque_Timestamp() { ticks = Convert.ToDateTime(new string(param_str.get())).Date.Ticks }; }
            //    (~time String): { String -> @Time!Interval } "convert string (local format) to time"
            public Aha.Base.Time.opaque_Interval op__time_String(IahaArray<char> param_str) { return new Aha.Base.Time.opaque_Interval() { ticks = Convert.ToDateTime(new string(param_str.get())).TimeOfDay.Ticks }; }
            //    (~timestamp String): { String -> @Time!Timestamp } "convert string (local format) to timestamp"
            //    (~money String): { String -> @Money!Money } "convert string (local format) to Money"
            //    (String <= String): { String, String } "compare string in local sorting order"
            public bool op_String_LessEqual_String(IahaArray<char> param_first, IahaArray<char> param_second)
            {
                return String.Compare(
                    new string(param_first.get()),
                    new string(param_second.get()),
                    StringComparison.CurrentCulture) <= 0;
            }
            //    (String < String): { String, String } "compare string in local sorting order"
            public bool op_String_Less_String(IahaArray<char> param_first, IahaArray<char> param_second)
            {
                return String.Compare(
                    new string(param_first.get()),
                    new string(param_second.get()),
                    StringComparison.CurrentCulture) < 0;
            }
            public bool op_String_Equal_String(IahaArray<char> param_first, IahaArray<char> param_second)
            {
                return String.Compare(
                    new string(param_first.get()),
                    new string(param_second.get()),
                    StringComparison.CurrentCulture) == 0;
            }
            public bool op_String_NotEqual_String(IahaArray<char> param_first, IahaArray<char> param_second)
            {
                return String.Compare(
                    new string(param_first.get()),
                    new string(param_second.get()),
                    StringComparison.CurrentCulture) != 0;
            }
            //    (String > String): { String, String } "compare string in local sorting order"
            public bool op_String_Greater_String(IahaArray<char> param_first, IahaArray<char> param_second)
            {
                return String.Compare(
                    new string(param_first.get()),
                    new string(param_second.get()),
                    StringComparison.CurrentCulture) > 0;
            }
            //    (String >= String): { String, String } "compare string in local sorting order"
            public bool op_String_GreateEqual_String(IahaArray<char> param_first, IahaArray<char> param_second)
            {
                return String.Compare(
                    new string(param_first.get()),
                    new string(param_second.get()),
                    StringComparison.CurrentCulture) >= 0;
            }
            //    (FilePath = FilePath): { FilePath, FilePath } "are paths the same?"
            public bool op_FilePath_Equal_FilePath(opaque_FilePath param_first, opaque_FilePath param_second)
            {
                return String.Compare(
                    param_first.value,
                    param_second.value,
                    StringComparison.InvariantCultureIgnoreCase) == 0;
            }
            //    (DirPath = DirPath): { DirPath, DirPath } "are paths the same?"
            public bool op_DirPath_Equal_DirPath(opaque_DirPath param_first, opaque_DirPath param_second)
            {
                return String.Compare(
                    param_first.value,
                    param_second.value,
                    StringComparison.InvariantCultureIgnoreCase) == 0;
            }
        }
    }

    namespace FileIOtypes
//doc 
//    Title: "FileIO"
//    Purpose: "File I/O (binary and text)"
//    Package: "Application Program Interface"
//    Author: "Roman Movchan, Melbourne, Australia"
//    Created: "2013-09-05"
//end

//use Time: Base/Time
//type String: [character] "alias for character array type"
//export Types:
//    type FileInfo:
//        [
//            fileType: String "file type"
//            modified: @Time!Timestamp "date/time of last modification"
//            size: integer "size in bytes"
//        ] "detailed file information"
//    type ErrorKind:
//        [
//            access: "access denied" |
//            IO: "permanent I/O error" |
//            notFound: "file or directory doesn't exist" |
//            nameClash: "file name already exists" |
//            outOfMemory: "out of memory" |
//            other: "other"
//        ] "error kind"
//    type ErrorInfo: 
//        [
//            kind: ErrorKind "error kind"
//            message: String "text message"
//        ] "error information"
//    type Encoding:
//        [
//            ANSI: "ANSI" |
//            UTF8: "UTF-8" |
//            UCS2LE: "UCS-2 Little Endian" |
//            UCS2BE: "UCS-2 Big Endian" |
//            auto: "automatic"
//        ] "text encoding"
//end
    {
        public interface icomp_FileInfo
        {
            IahaArray<char> attr_fileType();
            Aha.Base.Time.opaque_Timestamp attr_modified();
            Int64 attr_size();
        }

        public interface icomp_ErrorKind
        {
            bool attr1_access();
            bool attr2_IO();
            bool attr3_notFound();
            bool attr4_nameClash();
            bool attr5_outOfMemory();
            bool attr6_other();
        }

        public interface icomp_ErrorInfo
        {
            icomp_ErrorKind attr_kind();
            IahaArray<char> attr_message();
        }

        public interface icomp_Encoding
        {
            bool attr1_ASCII();
            bool attr2_UTF8();
            bool attr3_UCS2LE();
            bool attr4_UCS2BE();
            bool attr5_auto();
        }

    }

    namespace FileIO
//doc 
//    Title: "FileIO"
//    Purpose: "File I/O (binary and text) and file/directory management"
//    Package: "Application Program Interface"
//    Author: "Roman Movchan, Melbourne, Australia"
//    Created: "2013-09-12"
//end

//type Event: arbitrary "custom event type"
//use Jobs: API/Jobs(Event: Event)
//import Jobs(Types)
//use Env: API/Environment
//import Env(Types)
//use Bits: Base/Bits
//import Bits(Types)
//use Types: API/FileIOtypes
//import Types(Types)
//type String: [character] "alias for character array type"
//type ReadParams:
//    [ 
//        position: [ top: integer | bottom: integer | next: ] "position: from top (bytes), bottom (bytes) or current"
//        bytes: integer "number of bytes" 
//        result: { Bits -> Event } "event that receives bytes read"
//    ] "read given number of bytes at given position" 
//type WriteParams:
//    [ 
//        position: [ top: integer | bottom: integer | next: ] "position: from top (bytes), bottom (bytes) or current"
//        data: Bits "data to write (must be whole number of bytes)" 
//        written: Event "event raised upon writing"
//    ] "write data at given position" 
//type ReaderCommand:
//    [
//        read: ReadParams "read data" |
//        close: Event "release file for write operations and raise event"
//    ] "reader control commands"
//type WriterCommand:
//    [
//        write: WriteParams "write data" |
//        close: Event "release file for other operations and raise event"
//    ] "writer control commands"
//type Reader: { ReaderCommand -> Job } "return reader jobs"
//type Writer: { WriterCommand -> Job } "return writer jobs"
//type FileMngmt:
//    [
//        findFile: { [ path: FilePath yes: Event no: Event ] -> Job } "check if file with given path exists"
//        getFileInfo: { [ path: FilePath success: { FileInfo -> Event } error: { ErrorInfo -> Event } ] -> Job } 
//            "get detailed file information"
//        makeFile: { [ path: FilePath success: Event error: { ErrorInfo -> Event } ] -> Job } 
//            "create an empty file"
//        renameFile: { [ path: FilePath to: String success: Event error: { ErrorInfo -> Event } ] -> Job } 
//            "rename file"
//        deleteFile: { [ path: FilePath success: Event error: { ErrorInfo -> Event } ] -> Job } 
//            "delete a file"
//        findDir: { [ path: DirPath yes: Event no: Event ] -> Job } "check if directory with given path exists"
//        listDir: { [ path: DirPath success: { [ files: [String] dirs: [String] ] -> Event } error: { ErrorInfo -> Event } ] -> Job } 
//            "list files and subdirectories in given directory"
//        makeDir: { [ path: DirPath success: Event error: { ErrorInfo -> Event } ] -> Job } 
//            "create a directory"
//        renameDir: { [ path: DirPath to: String success: Event error: { ErrorInfo -> Event } ] -> Job } 
//            "rename directory"
//        deleteDir: { [ path: DirPath success: Event error: { ErrorInfo -> Event } ] -> Job } 
//            "delete a directory"
//    ] "file management jobs"
//type DirChange:
//    [
//        newFile: String "new file created" |
//        newDir: String "new subdirectory created" |
//        modified: String "file modified" |
//        deleted: String "file/subdirectory deleted" 
//    ] "changes in a directory"
//export Utils:
//    the CreateReader: { [ path: FilePath engine: Engine success: { Reader -> Event } error: { ErrorInfo -> Event } ] -> Job } "create file reader"
//    the CreateWriter: { [ path: FilePath engine: Engine success: { Writer -> Event } error: { ErrorInfo -> Event } ] -> Job } "create file writer"
//    the ReadText: 
//            { 
//                [ 
//                    path: FilePath 
//                    encoding: Encoding 
//                    success: { [ content: character* size: integer encoding: Encoding ] -> Event } 
//                    error: { ErrorInfo -> Event } 
//                    engine: Engine
//                ] -> Job 
//            } "job that returns text file content as a character sequence"
//    the WriteText: 
//            { 
//                [ 
//                    path: FilePath 
//                    encoding: Encoding 
//                    content: character*
//                    size: integer
//                    success: Event
//                    error: { ErrorInfo -> Event } 
//                    engine: Engine
//                ] -> Job 
//            } "job that creates text file from a character sequence"
//    the FileMngmt: { Engine -> FileMngmt } "obtain file management interface"
//    the DirWatch: { [ path: DirPath watch: { DirChange -> Event } error: { ErrorInfo -> Event } engine: Engine ] -> Job } 
//        "raise events when watched directory changes"
//    the DeleteWatch: { [ path: DirPath success: Event error: { ErrorInfo -> Event } engine: Engine ] -> Job } "delete directory watch"     
//end
    {
        public interface icomp_ReadParams<tpar_Event>
        {
            icomp_Position<tpar_Event> attr_position();
            Int64 attr_bytes();
            tpar_Event fattr_result(Aha.Base.Bits.opaque_BitString result);
        }

        public interface icomp_WriteParams<tpar_Event>
        {
            icomp_Position<tpar_Event> attr_position();
            Aha.Base.Bits.opaque_BitString attr_data();
            tpar_Event attr_written();
        }

        public interface icomp_Position<tpar_Event>
        {
            Int64 attr1_top();
            Int64 attr2_bottom();
            bool attr3_next();
        }

        public interface icomp_ReaderCommand<tpar_Event>
        {
            icomp_ReadParams<tpar_Event> attr1_read();
            tpar_Event attr2_close();
        }

        public interface icomp_WriterCommand<tpar_Event>
        {
            icomp_WriteParams<tpar_Event> attr1_write();
            tpar_Event attr2_close();
        }

        public delegate Jobs.opaque_Job<tpar_Event> func_Reader<tpar_Event>(icomp_ReaderCommand<tpar_Event> cmd);

        public delegate Jobs.opaque_Job<tpar_Event> func_Writer<tpar_Event>(icomp_WriterCommand<tpar_Event> cmd);

        public interface imod_FileIO<tpar_Event>
        {
            Jobs.opaque_Job<tpar_Event> fattr_CreateReader(icomp_CreateReaderParam<tpar_Event> param);
            Jobs.opaque_Job<tpar_Event> fattr_CreateWriter(icomp_CreateWriterParam<tpar_Event> param);
            Jobs.opaque_Job<tpar_Event> fattr_ReadText(icomp_ReadTextParam<tpar_Event> param);
            Jobs.opaque_Job<tpar_Event> fattr_WriteText(icomp_WriteTextParam<tpar_Event> param);
        }

        public interface icomp_CreateReaderParam<tpar_Event>
        {
            Aha.API.Environment.opaque_FilePath attr_path();
            Aha.API.Jobs.icomp_Engine<tpar_Event> attr_engine();
            tpar_Event fattr_success(func_Reader<tpar_Event> reader);
            tpar_Event fattr_error(FileIOtypes.icomp_ErrorInfo error);
        }

        public interface icomp_CreateWriterParam<tpar_Event>
        {
            Aha.API.Environment.opaque_FilePath attr_path();
            Aha.API.Jobs.icomp_Engine<tpar_Event> attr_engine();
            tpar_Event fattr_success(func_Writer<tpar_Event> writer);
            tpar_Event fattr_error(FileIOtypes.icomp_ErrorInfo error);
        }

        public interface icomp_ReadTextParam<tpar_Event>
        {
            Aha.API.Environment.opaque_FilePath attr_path();
            Aha.API.Jobs.icomp_Engine<tpar_Event> attr_engine();
            FileIOtypes.icomp_Encoding attr_encoding();
            tpar_Event fattr_success(icomp_TextReadParams<tpar_Event> result);
            tpar_Event fattr_error(FileIOtypes.icomp_ErrorInfo error);
        }

        public interface icomp_TextReadParams<tpar_Event>
        {
            IahaSequence<char> attr_content();
            Int64 attr_size();
            FileIOtypes.icomp_Encoding attr_encoding();
        }

        public interface icomp_WriteTextParam<tpar_Event>
        {
            Aha.API.Environment.opaque_FilePath attr_path();
            Aha.API.Jobs.icomp_Engine<tpar_Event> attr_engine();
            IahaSequence<char> attr_content();
            Int64 attr_size();
            FileIOtypes.icomp_Encoding attr_encoding();
            tpar_Event attr_success();
            tpar_Event fattr_error(FileIOtypes.icomp_ErrorInfo error);
        }

        public class module_FileIO<tpar_Event> : AhaModule, imod_FileIO<tpar_Event>
        {
            class ErrorInfo : Aha.API.FileIOtypes.icomp_ErrorKind, Aha.API.FileIOtypes.icomp_ErrorInfo
            {
                private System.Exception field_ex;
                public bool attr1_access() { return field_ex is System.Security.SecurityException || field_ex is System.UnauthorizedAccessException; }
                public bool attr2_IO() { return field_ex is System.IO.IOException; }
                public bool attr3_notFound() { return field_ex is System.IO.FileNotFoundException || field_ex is System.IO.DirectoryNotFoundException; }
                public bool attr4_nameClash() { return field_ex is System.IO.IOException; } //TODO
                public bool attr5_outOfMemory() { return field_ex is System.OutOfMemoryException; }
                public bool attr6_other() { return !(field_ex is System.Security.SecurityException || field_ex is System.UnauthorizedAccessException || field_ex is System.IO.IOException || field_ex is System.IO.FileNotFoundException || field_ex is System.IO.DirectoryNotFoundException || field_ex is System.OutOfMemoryException); }
                public FileIOtypes.icomp_ErrorKind attr_kind() { return this; }
                public IahaArray<char> attr_message() { return new AhaString(field_ex.Message); }
                public ErrorInfo(System.Exception param_ex)
                {
                    field_ex = param_ex;
                }
            }
            class Reader
            {
                private icomp_CreateReaderParam<tpar_Event> field_param;
                private System.IO.FileStream stream = null;
                icomp_ReadParams<tpar_Event> p;
                private async void read()
                {
                    try
                    {
                        if (stream == null)
                        {
                            stream = new System.IO.FileStream(field_param.attr_path().value, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                        }
                        try
                        {
                            Int64 pos = p.attr_position().attr1_top();
                            stream.Position = pos;
                        }
                        catch(Failure)
                        {
                            try
                            {
                                Int64 pos = p.attr_position().attr2_bottom();
                                stream.Position = stream.Length - pos;
                            }
                            catch(Failure)
                            {
                                // next
                            }
                        }
                        byte[] data = new byte[p.attr_bytes()];
                        int byteCount = await stream.ReadAsync(data, 0, (int)p.attr_bytes());
                        if (byteCount != p.attr_bytes()) { Array.Resize<byte>(ref data, byteCount); }
                        Aha.Base.Bits.opaque_BitString bits = new Base.Bits.opaque_BitString { bytes = data, bits = byteCount * 8 };
                        field_param.attr_engine().fattr_raise(p.fattr_result(bits)).execute();
                    }
                    catch(System.Exception ex)
                    {
                        field_param.attr_engine().fattr_raise(field_param.fattr_error(new ErrorInfo(ex))).execute();
                    }
                }
                private void close()
                {
                    if (stream != null)
                    {
                        stream.Dispose();
                        stream = null;
                    }
                }
                public Jobs.opaque_Job<tpar_Event> func_Reader(icomp_ReaderCommand<tpar_Event> cmd)
                {
                    try
                    {
                        p = cmd.attr1_read();                       
                        return new Jobs.opaque_Job<tpar_Event>
                        {
                            title = "Reader.read " + field_param.attr_path().value,
                            execute = read
                        };
                    }
                    catch(System.Exception)
                    {
                        return new Jobs.opaque_Job<tpar_Event>
                        {
                            title = "Reader.close " + field_param.attr_path().value,
                            execute = close
                        };
                    }
                }
                public Reader(icomp_CreateReaderParam<tpar_Event> param)
                {
                    field_param = param;
                }
            }
            class Writer
            {
                private icomp_CreateWriterParam<tpar_Event> field_param;
                private System.IO.FileStream stream = null;
                icomp_WriteParams<tpar_Event> p;
                private async void write()
                {
                    try
                    {
                        if (stream == null)
                        {
                            stream = new System.IO.FileStream(field_param.attr_path().value, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.None);
                        }
                        try
                        {
                            Int64 pos = p.attr_position().attr1_top();
                            stream.Position = pos;
                        }
                        catch (Failure)
                        {
                            try
                            {
                                Int64 pos = p.attr_position().attr2_bottom();
                                stream.Position = stream.Length - pos;
                            }
                            catch (Failure)
                            {
                                // next
                            }
                        }
                        byte[] data = p.attr_data().bytes;
                        await stream.WriteAsync(data, 0, data.Length);
                        field_param.attr_engine().fattr_raise(p.attr_written()).execute();
                    }
                    catch (System.Exception ex)
                    {
                        field_param.attr_engine().fattr_raise(field_param.fattr_error(new ErrorInfo(ex))).execute();
                    }
                }
                private void close()
                {
                    if (stream != null)
                    {
                        stream.Dispose();
                        stream = null;
                    }
                }
                public Jobs.opaque_Job<tpar_Event> func_Writer(icomp_WriterCommand<tpar_Event> cmd)
                {
                    try
                    {
                        p = cmd.attr1_write();
                        return new Jobs.opaque_Job<tpar_Event>
                        {
                            title = "Writer.write " + field_param.attr_path().value,
                            execute = write
                        };
                    }
                    catch (System.Exception)
                    {
                        return new Jobs.opaque_Job<tpar_Event>
                        {
                            title = "Writer.close " + field_param.attr_path().value,
                            execute = close
                        };
                    }
                }
                public Writer(icomp_CreateWriterParam<tpar_Event> param)
                {
                    field_param = param;
                }
            }
            private struct comp_TextReadParam : icomp_TextReadParams<tpar_Event>
            {
                public IahaSequence<char> field_content;
                public Int64 field_size;
                public FileIOtypes.icomp_Encoding field_encoding;
                public IahaSequence<char> attr_content() { return field_content; }
                public Int64 attr_size() { return field_size; }
                public FileIOtypes.icomp_Encoding attr_encoding() { return field_encoding; }
            }
            public Jobs.opaque_Job<tpar_Event> fattr_CreateReader(icomp_CreateReaderParam<tpar_Event> param)
            {
                Reader reader = new Reader(param);
                return new Jobs.opaque_Job<tpar_Event>
                    {
                        title = "CreateReader " + param.attr_path().value,
                        execute =
                            delegate()
                            {
                                param.attr_engine().fattr_raise(param.fattr_success(reader.func_Reader)).execute();
                            }
                    };
            }
            public Jobs.opaque_Job<tpar_Event> fattr_CreateWriter(icomp_CreateWriterParam<tpar_Event> param)
            {
                Writer writer = new Writer(param);
                return new Jobs.opaque_Job<tpar_Event>
                {
                    title = "CreateWriter " + param.attr_path().value,
                    execute =
                        delegate()
                        {
                            param.attr_engine().fattr_raise(param.fattr_success(writer.func_Writer)).execute();
                        }
                };
            }
            struct FileText : IahaSequence<char>
            {
                public List<string> list;
                public int index;
                public int block;
                public char state() { return list[block][index]; }
                public IahaObject<char> copy() { FileText clone = new FileText { list = list, index = index, block = block }; return clone; }
                public void action_skip() { if (index == list[block].Length) { index = 0; block++; } else index++; }
                public char first(Predicate<char> that, Int64 max) 
                { 
                    Int64 j = 0; 
                    int i = index; 
                    int b = block; 
                    char item = list[block][index]; 
                    while (j < max) 
                    { 
                        item = list[b][i]; 
                        if (that(item)) return item;
                        if (i == list[b].Length) { i = 0; b++; } else i++;
                        j++; 
                    } 
                    throw Failure.One; 
                }
            }
            struct FileEncoding : FileIOtypes.icomp_Encoding
            {
                public Encoding field_encoding;
                bool FileIOtypes.icomp_Encoding.attr1_ASCII()
                {
                    return field_encoding.Equals(Encoding.ASCII);
                }

                bool FileIOtypes.icomp_Encoding.attr2_UTF8()
                {
                    return field_encoding.Equals(Encoding.UTF8);
                }

                bool FileIOtypes.icomp_Encoding.attr3_UCS2LE()
                {
                    return field_encoding.Equals(Encoding.Unicode);
                }

                bool FileIOtypes.icomp_Encoding.attr4_UCS2BE()
                {
                    return field_encoding.Equals(Encoding.BigEndianUnicode);
                }

                bool FileIOtypes.icomp_Encoding.attr5_auto()
                {
                    return field_encoding.Equals(Encoding.Default);
                }
            }
            public Jobs.opaque_Job<tpar_Event> fattr_ReadText(icomp_ReadTextParam<tpar_Event> param)
            {

                return new Jobs.opaque_Job<tpar_Event>
                {
                    title = "ReadText " + param.attr_path().value,
                    execute =
                        async delegate ()
                        {
                            System.IO.FileStream stream = null;
                            const int block = 8192;
                            System.Text.Encoding encoding;
                            try
                            {
                                stream = new System.IO.FileStream(param.attr_path().value, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                                FileText text = new FileText() { list = new List<string>(), block = 0, index = 0 };
                                if (param.attr_encoding().attr1_ASCII())
                                { encoding = Encoding.ASCII; }
                                else
                                    if (param.attr_encoding().attr2_UTF8())
                                    { encoding = Encoding.UTF8; }
                                    else
                                        if (param.attr_encoding().attr3_UCS2LE())
                                        { encoding = Encoding.Unicode; }
                                        else
                                            if (param.attr_encoding().attr4_UCS2BE())
                                            { encoding = Encoding.BigEndianUnicode; }
                                            else
                                            { encoding = null; } 
                                while (stream.Position < stream.Length)
                                {
                                    byte[] data = new byte[block];
                                    int byteCount = await stream.ReadAsync(data, 0, block);
                                    if (byteCount != block) { Array.Resize<byte>(ref data, byteCount); }
                                    if (encoding == null)
                                    {
                                        if (byteCount > 2 && data[0] == 0xEF && data[1] == 0xBB && data[2] == 0xBF)
                                            encoding = Encoding.UTF8;
                                        else
                                            if (byteCount > 1 && data[0] == 0xFE && data[1] == 0xFF)
                                                encoding = Encoding.BigEndianUnicode;
                                            else
                                                if (byteCount > 1 && data[0] == 0xFF && data[1] == 0xFE)
                                                    encoding = Encoding.Unicode;
                                                else
                                                    encoding = Encoding.Default;
                                        text.index = encoding.GetCharCount(encoding.GetPreamble());
                                    }
                                    text.list.Add(encoding.GetString(data));
                                }
                                comp_TextReadParam p = new comp_TextReadParam() { field_encoding = new FileEncoding { field_encoding = encoding }, field_size = stream.Length, field_content = text };
                                param.attr_engine().fattr_raise(param.fattr_success(p)).execute();
                            }
                            catch (System.Exception ex)
                            {
                                param.attr_engine().fattr_raise(param.fattr_error(new ErrorInfo(ex))).execute();
                            }
                            finally
                            {
                                if (stream != null) stream.Dispose();
                            }
                        }
                };
            }
            public Jobs.opaque_Job<tpar_Event> fattr_WriteText(icomp_WriteTextParam<tpar_Event> param)
            {

                return new Jobs.opaque_Job<tpar_Event>
                {
                    title = "WriteText " + param.attr_path().value,
                    execute =
                        async delegate()
                        {
                            System.IO.FileStream stream = null;
                            const int block = 4096;
                            System.Text.Encoding encoding;
                            try
                            {
                                stream = new System.IO.FileStream(param.attr_path().value, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.None);
                                if (param.attr_encoding().attr1_ASCII())
                                { encoding = Encoding.ASCII; }
                                else
                                    if (param.attr_encoding().attr2_UTF8())
                                    { encoding = Encoding.UTF8; }
                                    else
                                        if (param.attr_encoding().attr3_UCS2LE())
                                        { encoding = Encoding.Unicode; }
                                        else
                                            if (param.attr_encoding().attr4_UCS2BE())
                                            { encoding = Encoding.BigEndianUnicode; }
                                            else
                                            { encoding = Encoding.Default; }
                                byte[] BOM = encoding.GetPreamble();
                                if (BOM.Length > 0)
                                {
                                    await stream.WriteAsync(BOM, 0, BOM.Length);
                                }
                                char[] data = new char[block];
                                Int64 left = param.attr_size();
                                int size = block;
                                IahaSequence<char> seq = (IahaSequence<char>)param.attr_content().copy();
                                while (left > 0)
                                {
                                    if (left < block) size = (int)left;
                                    for (int i = 0; i < size; i++)
                                    {
                                        try
                                        {
                                            data[i] = seq.state();
                                            try { seq.action_skip(); }
                                            catch (Failure) { size = i + 1; left = size; }
                                        }
                                        catch (Failure) { size = i; left = size; }
                                    }
                                    if (size != block) Array.Resize<char>(ref data, size);
                                    byte[] buf = encoding.GetBytes(data);
                                    await stream.WriteAsync(buf, 0, buf.Length);
                                    left -= size;
                                }
                                param.attr_engine().fattr_raise(param.attr_success()).execute();
                            }
                            catch (System.Exception ex)
                            {
                                param.attr_engine().fattr_raise(param.fattr_error(new ErrorInfo(ex))).execute();
                            }
                            finally
                            {
                                if (stream != null) stream.Dispose();
                            }
                        }
                };
            }
        }

    }

    namespace Application
    //doc 
    //    Title: "Application"
    //    Purpose: "A console application"
    //    Package: "Application Program Interface"
    //    Author: "Roman Movchan, Melbourne, Australia"
    //    Created: "2013-27-08"
    //end

    //type Event: opaque "must be defined by the implementation"
    //use Jobs: API/Jobs(Event: Event)
    //the Title: [character]  "application title"
    //the Signature: [character]  "vendor's signature"
    //the Behavior: { [ settings: [character] password: [character] output: { [character] -> @Jobs!Job } engine: @Jobs!Engine ] -> @Jobs!Behavior } "application behavior"
    //the Receive: { [character] -> Event } "convert user input to events"
    {
        public partial struct opaque_Event { }

        public interface icomp_BehaviorParams
        {
            IahaArray<char> attr_settings();
            IahaArray<char> attr_password();
            Jobs.opaque_Job<opaque_Event> fattr_output(IahaArray<char> text);
            Jobs.icomp_Engine<opaque_Event> attr_engine();
        }

        public interface imod_Application
        {
            IahaArray<char> attr_Title();
            IahaArray<char> attr_Signature();
            Jobs.iobj_Behavior<opaque_Event> fattr_Behavior(icomp_BehaviorParams param_param);
            opaque_Event fattr_Receive(IahaArray<char> param_input);
        }
    }

    namespace Process
//doc 
//    Title: "Process"
//    Purpose: "Use a component that runs a job"
//    Package: "Application Program Interface"
//    Author: "Roman Movchan, Melbourne, Australia"
//    Created: "2013-09-06"
//end

//type Settings: arbitrary "component settings"
//type Output: arbitrary "component output"
//type Event: arbitrary "client's event type"
//use Jobs: API/Jobs(Event: Event)
//the CreateProcess: { [ classname: [character] password: [character] engine: @Jobs!Engine settings: Settings output: { Output -> Event } ] -> @Jobs!Job } "return job that creates process"
    {
        public interface icomp_ProcessParam<tpar_Settings, tpar_Output, tpar_Event>
        {
            IahaArray<char> attr_classname();
            IahaArray<char> attr_password();
            Aha.API.Jobs.icomp_Engine<tpar_Event> attr_engine();
            tpar_Settings attr_settings();
            tpar_Event fattr_output(tpar_Output output);
        }

        public interface imod_Process<tpar_Settings, tpar_Output, tpar_Event>
        {
            Aha.API.Jobs.opaque_Job<tpar_Event> fattr_CreateProcess(icomp_ProcessParam<tpar_Settings, tpar_Output, tpar_Event> param);
        }

        public class module_Process<tpar_Settings, tpar_Output, tpar_Event> : AhaModule, imod_Process<tpar_Settings, tpar_Output, tpar_Event>
        {
            delegate tpar_Event func_Output(tpar_Output output);

            class comp_BehaviorParams<opaque_Event> : ProcessDef.icomp_BehaviorParams
            {
                private tpar_Settings field_settings;
                private IahaArray<char> field_password;
                private func_Output field_output;
                private Aha.API.Jobs.icomp_Engine<tpar_Event> field_engine;
                private Aha.API.Jobs.icomp_Engine<opaque_Event> field_engine2;
                public tpar_Settings attr_settings() { return field_settings; }
                public IahaArray<char> attr_password() { return field_password; }
                public Jobs.opaque_Job<opaque_Event> fattr_output(tpar_Output output) 
                {
                    return new Jobs.opaque_Job<opaque_Event>
                    {
                        title = "output",
                        execute =
                            delegate()
                            {
                                field_engine.fattr_raise(field_output(output)).execute();
                            }
                    };
                }
                public Jobs.icomp_Engine<opaque_Event> attr_engine() { return field_engine2; }
                public comp_BehaviorParams(tpar_Settings param_settings, IahaArray<char> param_password, func_Output param_output, Aha.API.Jobs.icomp_Engine<tpar_Event> param_engine, Aha.API.Jobs.icomp_Engine<opaque_Event> param_engine2) 
                {
                    field_settings = param_settings;
                    field_password = param_password;
                    field_output = param_output;
                    field_engine = param_engine;
                    field_engine2 = param_engine2;
                }
            }

            public Aha.API.Jobs.opaque_Job<tpar_Event> fattr_CreateProcess(icomp_ProcessParam<tpar_Settings, tpar_Output, tpar_Event> param)
            {
                string classname = new string(param.attr_classname().get());
                return new Jobs.opaque_Job<tpar_Event>
                {
                    title = "CreateProcess " + classname,
                    execute =
                        delegate()
                        {
                            string path = (string)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\Aha! for .NET\\Components\\" + classname, "Path", "");
                            if (!path.Equals(""))
                            {
                                try
                                {
                                    System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(path);
                                    Type eventType = assembly.GetType("opaque_Event", true, false);
                                    Type engType = typeof(Aha.Engine.comp_Engine<>).MakeGenericType(new Type[] { eventType });
                                    Object eng = Activator.CreateInstance(engType);
                                    Type bpType = typeof(comp_BehaviorParams<>).MakeGenericType(new Type[] { eventType });
                                    func_Output output = param.fattr_output;
                                    Object bp = Activator.CreateInstance(bpType, new Object[] { param.attr_settings(), param.attr_password(), output, param.attr_engine(), eng  });
                                    foreach (Type type in assembly.ExportedTypes)
                                    {
                                        if (type.IsClass)
                                        {
                                            try
                                            {
                                                ProcessDef.imod_ProcessDef proc = Activator.CreateInstance(type) as ProcessDef.imod_ProcessDef;
                                                if (proc != null)
                                                {
                                                    engType.InvokeMember("StartExternal", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.InvokeMethod, null, eng, new Object[] { bp });
                                                    return;
                                                }
                                            }
                                            catch (System.Exception) { }
                                        }
                                    }
                                    // "Error: assembly doesn't contain an Aha! component";
                                }
                                catch (System.Exception) { } //Error: type parameters don't match
                            }
                        } // Error: classname is not registered
                };
            }
        }

        namespace ProcessDef
//doc 
//    Title: "ProcessDef"
//    Purpose: "Definition of a process component"
//    Package: "Application Program Interface"
//    Author: "Roman Movchan, Melbourne, Australia"
//    Created: "2013-09-06"
//end

//type Settings: opaque "component's settings (set at creation of an instance)"
//type Output: opaque "component's output (created using an output job)"
//type Event: opaque "custom event type"
//use Jobs: API/Jobs<Event: Event>
//the Title: [character] "component's title"  
//the Behavior: { [ settings: Settings password: [character] output: { Output -> @Jobs!Job } engine: @Jobs!Engine ] -> @Jobs!Behavior } "component's behavior"
        {
            public partial struct opaque_Settings { }

            public partial struct opaque_Output { }

            public partial struct opaque_Event { }

            public interface icomp_BehaviorParams
            {
                opaque_Settings attr_settings();
                IahaArray<char> attr_password();
                Jobs.opaque_Job<opaque_Event> fattr_output(opaque_Output text);
                Jobs.icomp_Engine<opaque_Event> attr_engine();
            }

            public interface imod_ProcessDef
            {
                IahaArray<char> attr_Title();
                IahaArray<char> attr_Signature();
                Jobs.iobj_Behavior<opaque_Event> fattr_Behavior(icomp_BehaviorParams param_param);
            }
        }

    }
}
