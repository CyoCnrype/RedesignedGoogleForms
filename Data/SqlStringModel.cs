using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SqlStringModel
    {
        /// <summary>
        /// 查詢Form用字串
        /// </summary>
        public static string elementsForSearchForm =
            @" 
                        [FormNumber]
                       ,[FormTag]
                       ,[FormTitle]
                       ,[IsAvailable]
                       ,[FormStartTime]
                       ,[FormEndTime]
                       ,[FormEstablishedTime]
                       ,[FormDescription]
                       ,[FormCount]
                       ,[FormID]
                       ,[FormIsDeleted]
                ";

        /// <summary>
        /// 新增Form用字串
        /// </summary>
        public static string elementsForInsertNewForm =
            @" 
                       [FormTag]
                       ,[FormTitle]
                       ,[IsAvailable]
                       ,[FormStartTime]
                       ,[FormEndTime]
                       ,[FormDescription]
                       ,[FormCount]
                       ,[FormID]
                       ,[FormIsDeleted]
                ";

        /// <summary>
        /// 查詢問題用字串
        /// </summary>
        public static string elementsForSearchQuestion =
            @" 
                      [QueNumber]
                     ,[QueTag]
                     ,[QueText]
                     ,[QueSelection]
                     ,[IsAvailable]
                     ,[QueSelectionType]
                     ,[QueIsMust]
                     ,[QueID]
                ";

        /// <summary>
        /// 新增問題用字串
        /// </summary>
        public static string elementsForInsertNewQuestion =
                    @" 
                     [QueTag]
                     ,[QueText]
                     ,[QueSelection]
                     ,[IsAvailable]
                     ,[QueSelectionType]
                     ,[QueIsMust]
                     ,[QueID]
                ";

        /// <summary>
        /// 查詢常用問題用字串
        /// </summary>
        public static string elementsForSearchFreqQuestion =
                    @"  
                  [QueNumber]
                 ,[QueTag]
                 ,[QueText]
                 ,[QueSelection]
                 ,[IsAvailable]
                 ,[QueSelectionType]
                 ,[QueIsMust]
                ";

        /// <summary>
        /// 新增常用問題用字串
        /// </summary>
        public static string elementsForInsertNewFreqQuestion =
                    @"  
                    [QueText]
                    ,[QueSelection]
                    ,[IsAvailable]
                    ,[QueSelectionType]
                    ,[QueIsMust]
                ";

    

        //
    }
}
