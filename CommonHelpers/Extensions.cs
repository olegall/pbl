using System;
using System.Net.Sockets;
using System.Text;

namespace CommonHelpers
{
    public static class Extensions
    {
        public static string FullErrorMessage(this Exception ex)
        {
            if (ex == null)
            {
                return null;
            }
            var message = new StringBuilder();
            do
            {
                message.AppendLine(ex.Message);
                ex = ex.InnerException;
            } while (ex != null);

            return message.ToString();
        }

        public static void WriteAll(this NetworkStream stream, byte[] buf)
        {
            stream.Write(buf, 0, buf.Length);
        }

        public static int ReadAll(this NetworkStream stream, byte[] buf)
        {
            return stream.Read(buf, 0, buf.Length);
        }
    }
}