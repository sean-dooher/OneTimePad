using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnePad
{
    public class Key
    {
        #region Private Fields
        private string keyPath = AppDomain.CurrentDomain.BaseDirectory + "key.pad";
        private RandomNumberGenerator rng;
        private int index;
        private int size;
		#endregion
        #region Public Fields
		/// <summary>
		/// Writing index of key
		/// </summary>
        public int Index
        {
            get
            {
                return index;
            }
        }
		/// <summary>
		/// Size of key in bytes
		/// </summary>
        public int Size
        {
            get
            {
                return size;
            }
        }
		/// <summary>
		/// Bytes left in array that are not written to yet
		/// </summary>
        public int BytesLeft
        {
            get
            {
                return Size - Index;
            }
        }
        #endregion
        #region Events
        /// <summary>
        /// Reports when the current index of the key changes
        /// </summary>
        public event EventHandler<int> IndexChanged;
		/// <summary>
		/// Reports when the progress of encoding a file increases by 1%
		/// </summary>
        public event EventHandler<int> EncodeFileProgress;
        /// <summary>
        /// Reports when the progress of decoding a file increases by 1%
        /// </summary>
        public event EventHandler<int> DecodeFileProgress;
        private event EventHandler<int> KeyCreatedProgress;
        #endregion

        #region Constructors
        /// <summary>
		/// Creates a new key with a specified length and saves it to the application folder with name "key.pad"
		/// </summary>
		/// <param name="length">Length of key</param>
        /// <param name="keyProgress">Event handler for progress of key creation</param>
        public Key(int length, EventHandler<int> keyProgress = null)
        {
            KeyCreatedProgress += keyProgress;
            index = 0;
            size = length;
            using (FileStream stream = new FileStream(keyPath, FileMode.Create))
            {
                byte[] key = new byte[length];
                rng = new RNGCryptoServiceProvider();
                rng.GetBytes(key);
                stream.Seek(0, SeekOrigin.Begin);
                stream.Write(BitConverter.GetBytes(index), 0, 4);
                for (int i = 0; i < key.Length; i++)
                {
                    double percent = i * 100.0 / key.Length;
                    if (percent - (int)percent == 0)
                    {
                        KeyCreatedProgress(this, (int)percent);
                    }
                    stream.WriteByte(key[i]);
                }
            }
        }

        /// <summary>
		/// Creates a new Key of a specified length
		/// </summary>
		/// <param name="length">Length of key</param>
        /// <param name="savepath">Path to save key to</param>
        /// <param name="keyProgress">Event handler for progress of key creation</param>
        public Key(int length, string savepath, EventHandler<int> keyProgress = null)
        {
            KeyCreatedProgress += keyProgress;
            index = 0;
            size = length;
            if (Directory.Exists(Path.GetDirectoryName(savepath))) keyPath = savepath;
            using (FileStream stream = new FileStream(keyPath, FileMode.Create))
            {
                byte[] key = new byte[length];
                rng = new RNGCryptoServiceProvider();
                rng.GetBytes(key);
                stream.Seek(0, SeekOrigin.Begin);
                stream.Write(BitConverter.GetBytes(index), 0, 4);
                for (int i = 0; i < key.Length; i++)
                {
                    double percent = i * 100.0 / key.Length;
                    if (percent - (int)percent == 0)
                    {
                        KeyCreatedProgress(this, (int)percent);
                    }
                    stream.WriteByte(key[i]);
                }
            }
        }

		/// <summary>
		/// Attempts to open a Key from a specified path. If no file exists, creates a new Key with length 0.
        /// If directory doesn't exist, key is created in application folder as "key.pad"
		/// </summary>
		/// <param name="filepath">Path to attempt to open as a key</param>
        public Key(string filepath)
        {
            if(Directory.Exists(Path.GetDirectoryName(filepath))) keyPath = filepath;
            try
            {
                using (FileStream fs = new FileStream(filepath, FileMode.Open))
                {
                    fs.Seek(0, SeekOrigin.Begin);
                    byte[] indexArray = new byte[4];
                    fs.Read(indexArray, 0, 4);
                    index = BitConverter.ToInt32(indexArray, 0);
                    fs.Close();
                }
                size = (int)new FileInfo(filepath).Length;
            }
            catch (IOException)
            {
                index = 0;
                size = 0;
                rng = new RNGCryptoServiceProvider();
                File.WriteAllBytes(keyPath, new byte[0]);
            }
			
        }
        #endregion

        #region Methods
        /// <summary>
		/// Adds a specified amount of bytes onto the end of the key
		/// </summary>
		/// <param name="count">Number of bytes to add to key</param>
		/// <returns>Returns true if bytes are sucessfully added, returns false otherwise</returns>
        public bool AddBytes(int count)
        {
            try
            {
                using (FileStream stream = new FileStream(keyPath, FileMode.Append))
                {
                    byte[] newBytes = new byte[count];
                    rng.GetBytes(newBytes);
                    stream.Write(newBytes, 0, newBytes.Length);
                    stream.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

		/// <summary>
		/// Removes a specified amount of bytes from the end of the key
		/// </summary>
		/// <param name="count">Number of bytes to remove from key</param>
        /// <returns>Returns true if bytes are sucessfully removed, returns false otherwise</returns>
        public bool RemoveBytes(int count)
        {
            try
            {
				using(FileStream stream = new FileStream(keyPath,FileMode.Open))
				{
                    stream.SetLength(Math.Max(0, size - count));
                    stream.Close();
                }
                size = Math.Max(0, size - count);
            }
            catch
            {
                return false;
            }
            return true;
        }

        #region Encode
        /// <summary>
		/// Encodes a file from a specified path and saves the encoded file to the same directory
		/// </summary>
		/// <param name="filepath">Path of file to encode</param>
		/// <returns>Returns true if file is successfully encoded, returns false otherwise</returns>
        public bool EncodeFile(string filepath)
        {
            return EncodeFile(filepath, Path.ChangeExtension(filepath, ".padf"));
        }

		/// <summary>
        /// Encodes a file from a specified path and saves it to a specified path
		/// </summary>
        /// <param name="filepath">Path of file to encode</param>
		/// <param name="savepath">Path to save encoded file to</param>
        /// <returns>Returns true if file is successfully encoded, returns false otherwise</returns>
        public bool EncodeFile(string filepath, string savepath)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(savepath))) savepath = Path.ChangeExtension(filepath, "padf");
                using (FileStream stream = new FileStream(filepath, FileMode.Open))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    byte[] ext = Encoding.ASCII.GetBytes(Path.GetExtension(filepath));
                    byte[] data = new byte[new FileInfo(filepath).Length + ext.Length];
                    for (int i = 0; i < ext.Length; i++) //sets extension in data
                    {
                        data[i] = ext[i];
                    }

                    //read file and report progress
                    int oldPercent = 0;
                    for (int i = 0; i < data.Length - ext.Length; i++)
                    {
                        int percent = (100 * i) / (data.Length-ext.Length);
                        if (percent - oldPercent >= 1)
                        {
                            oldPercent = percent;
                            EncodeFileProgress(this, percent);
                        }
                        data[ext.Length + i] = (byte)stream.ReadByte();
                    }
                    stream.Close();

                    if (EncodeFile(data))//if the data is successfully encoded
                    {
                        using (FileStream write = new FileStream(savepath, FileMode.Create))//write data to file
                        {
                            oldPercent = 0;
                            write.Seek(0, SeekOrigin.Begin);
                            write.Write(BitConverter.GetBytes(index-data.Length), 0, 4);//write index of key to file
                            write.Write(BitConverter.GetBytes((Path.GetExtension(filepath)).Length), 0, 4);
                            for (int i = 0; i < data.Length; i++)//write encoded data to file
                            {
                                int percent = (100 * i) / data.Length;
                                if (percent - oldPercent >= 1)
                                {
                                    oldPercent = percent;
                                    EncodeFileProgress(this, percent);
                                }
                                write.WriteByte(data[i]);
                            }
                            write.Flush();
                            write.Close();
                        }
                    }

                    else return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

		/// <summary>
		/// Encodes byte array with the key
		/// </summary>
		/// <param name="data">Data(in bytes) to encode</param>
        /// <returns>Returns true if file is successfully encoded, returns false otherwise</returns>
        public bool EncodeFile(byte[] data)
        {
            try
            {
                using (FileStream stream = new FileStream(keyPath, FileMode.Open))
                {
                    int oldPercent = 0;
                    stream.Seek(index + 4, SeekOrigin.Begin);
                    for (int i = 0; i < data.Length; i++)
                    {
                        int percent = (i * 100) / data.Length;
                        if (percent - oldPercent >= 1)
                        {
                            oldPercent = percent;
                            EncodeFileProgress(this, percent);
                        }
                        data[i] = ModAdd(data[i], (byte)stream.ReadByte());
                    }
                    stream.Close();
                    ChangeIndexFile(index + data.Length);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Decode
        /// <summary>
        /// Decodes a file from a specified path and then saves the file in the same path
        /// </summary>
        /// <param name="filepath">File to decode</param>
        /// <returns>Returns true if file is successfully decoded, returns false otherwise</returns>
        public bool DecodeFile(string filepath)
        {
            return DecodeFile(filepath,Path.ChangeExtension(filepath,GetEncodedExtension(filepath)));
        }

        public bool DecodeFile(string filepath, string savepath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(savepath))) savepath = Path.ChangeExtension(filepath, Path.GetExtension(savepath));
            try
            {
                using (FileStream stream = new FileStream(filepath, FileMode.Open))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    byte[] metadata = new byte[8];
                    stream.Read(metadata, 0, 8);
                    int index = BitConverter.ToInt32(metadata, 0);
                    int extLen = BitConverter.ToInt32(metadata, 4);
                    byte[] data = new byte[new FileInfo(filepath).Length - metadata.Length - extLen];
                    stream.Seek(extLen, SeekOrigin.Current);
                    int oldPercent = 0;
                    for (int i = 0; i < data.Length; i++)
                    {
                        int percent = (i * 100) / data.Length;
                        if (percent - oldPercent >= 1)
                        {
                            oldPercent = percent;
                            DecodeFileProgress(this, percent);
                        }
                        data[i] = (byte)stream.ReadByte();
                    }
                    DecodeFile(index + extLen, data);
                    using (FileStream fS = new FileStream(savepath, FileMode.Create))
                    {
                        oldPercent = 0;
                        for (int i = 0; i < data.Length; i++)
                        {
                            int percent = (i * 100) / data.Length;
                            if (percent - oldPercent >= 1)
                            {
                                oldPercent = percent;
                                DecodeFileProgress(this, percent);
                            }
                            fS.WriteByte(data[i]);
                        }
                        fS.Close();
                    }
                    stream.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Decodes specified byte array with this key
        /// </summary>
        /// <param name=
        /// "index">Index of key to start at</param>
        /// <param name="data">Data array</param>
        /// <returns>Returns true if the data in the array is succesfully encoded, false otherwise</returns>
        public bool DecodeFile(int index, byte[] data)
        {
            try
            {
                using (FileStream stream = new FileStream(keyPath, FileMode.Open))
                {
                    int oldPercent = 0;
                    stream.Seek(index + 4, SeekOrigin.Begin);
                    for (int i = 0; i < data.Length; i++)
                    {
                        int percent = (i * 100) / data.Length;
                        if (percent - oldPercent >= 1)
                        {
                            oldPercent = percent;
                            DecodeFileProgress(this, percent);
                        }
                        byte keyB = (byte)stream.ReadByte();
                        data[i] = ModSub(data[i], keyB);
                    }
                    stream.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        /// <summary>
        /// Returns the original extension of a file encoded with this key
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public string GetEncodedExtension(string filepath)
        {
            try
            {
                using (FileStream stream = new FileStream(filepath, FileMode.Open))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    byte[] indexArray = new byte[4];
                    stream.Read(indexArray, 0, 4);

                    int extIndex = BitConverter.ToInt32(indexArray, 0);
                    byte[] extLenArray = new byte[4];
                    stream.Read(extLenArray, 0, 4);
                    int extLen = BitConverter.ToInt32(extLenArray, 0);

                    byte[] ext = new byte[extLen];
                    stream.Read(ext, 0, ext.Length);
                    DecodeFile(extIndex, ext);
                    stream.Close();
                    return Encoding.ASCII.GetString(ext);
                }
            }
            catch
            {
                return null;
            }
        }

        public static byte[] operator +(Key enc, byte[] file)
        {
            enc.EncodeFile(file);
            return file;
        }
        #endregion

        #region Helper Methods
        private void ChangeIndexFile(int newIndex)
        {
                using(FileStream stream = new FileStream(keyPath,FileMode.Open))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.Write(BitConverter.GetBytes(newIndex), 0, 4);
                    stream.Close();
                }
                this.index = newIndex;
                IndexChanged(this, index);
        }

        private byte ModAdd(byte i, byte j)
        {
            return i >= j ? (byte)(i - j) : (byte)(256 - j + i);
        }

        private byte ModSub(byte i, byte j)
        {
            if (j == 0) return i;
            j = (byte)(256 - j);
            return i >= j ? (byte)(i - j) : (byte)(256 - j + i);
        }
        #endregion
    }
}
