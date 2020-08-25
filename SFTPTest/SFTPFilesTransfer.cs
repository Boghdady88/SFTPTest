using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace SFTPTest
{
    class SFTPFilesTransfer
    {
        public int SendFiles(int transferOption)
        {
            try
            {
                // Setup session options
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = "192.168.1.2",
                    UserName = "ahmed",
                    Password = "password",
                    PortNumber = 22,
                    SshHostKeyFingerprint = "ssh-rsa 2048 tqUh6FiQbei1WwS6WQrYygRRuFRbti32LnLukFfSLtw=" //ssh host key
                };

                using (Session session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);

                    // Upload files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;

                    TransferOperationResult transferResult;
                    if (transferOption == 1)
                    {
                      transferResult = session.PutFiles(@"D:\ForVideos\*", "/public/", false, transferOptions);
                    }
                    else
                    {
                      transferResult = session.GetFiles(@"/public/", @"C:\Users\DAR-F\Downloads\RebexTinySftpServer-Binaries-Latest\data\local\*", false, transferOptions);
                    }
                    // Throw on any error
                    transferResult.Check();

                    // Print results
                    foreach (TransferEventArgs transfer in transferResult.Transfers)
                    {
                        Console.WriteLine("Upload of {0} succeeded", transfer.FileName);
                    }
                }

                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
                return 1;
            }
        }
    }
}
