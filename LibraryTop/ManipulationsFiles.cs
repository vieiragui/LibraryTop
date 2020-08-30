using System;
using System.IO;

namespace LibraryTop
{
    /// <summary>
    /// This class contains methods and functions for handling files
    /// </summary>
    public class ManipulationsFiles
    {
        /// <summary>
        /// The functions delete file.
        /// </summary>
        /// <param name="file">Full name file</param>
        /// <returns>Return message with information that file has been deleted.</returns>
        public string DeleteFile(string file)
        {
            try
            {
                File.Delete(file);

                return $"The file {file} has been deleted.";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error when try deleting file. Message: {ex.Message}");
            }

        }

        /// <summary>
        /// Search for a file
        /// </summary>
        /// <param name="file">Full name file</param>
        /// <returns>Return boolean value. True case exist file or false if file don't exist;</returns>
        public bool FileExist(string file)
        {
            try
            {
                return File.Exists(file);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error when try search file. Message: {ex.Message}");
            }
        }


    }
}
