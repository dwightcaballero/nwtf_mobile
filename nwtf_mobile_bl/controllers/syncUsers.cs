
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace nwtf_mobile_bl
{
    public partial class controllers
    {
        public class syncUsers
        {
        //    public string syncUser(String username, String password)
        //    {
        //        //get user record
        //        //check if empty
        //        //check password if match(parameters:GUID, password)

        //        //get user record
        //        views.vwTempUsers usrRec = views.vwTempUsers.getUser(username, password);
        //        //check if empty record
        //        if (usrRec == null)
        //        {
        //            return "Invalid username or password!";
        //        }
        //        //check if password match
        //        if (!IsPwdMatch(usrRec.id, password))
        //        {
        //            return "Invalid user name or password!";
        //        }
        //    //    'password matches
        //    //    If Not IsPwdMatch(usrRec.id, pwd) Then
        //    //        Return "Invalid user name or password!"
        //    //    End If
        //    //    'the workgroup of the user is existing
        //    //    Dim wgRecord = dataservices.workgroup.getWorkGroupbyID(usrRec.workgroupid)
        //    //    If wgRecord Is Nothing Then
        //    //        Return "Cannot find your workgroup assignment"
        //    //    End If
        //    //    'the worgroup of the user is active
        //    //    If wgRecord.Status = systool.Status_InActive Then
        //    //        Return "You workgroup assignment is inactive"
        //    //    End If

        //    //    WorkgroupName = wgRecord.wgname

        //    //    Dim AssignedModule = views.vwModuleForSelection.getModuleByWorkGroupID(usrRec.workgroupid)
        //    //    AssignedModule = (From p In AssignedModule Where p.App = app And p.isInclude = True Select p).ToList
        //    //    userMenus = New List(Of AppMenuItem)
        //    //    listBranchBlock = views.vwUserBranchBlock.getUserBranchByUserID(usrRec.id)

        //    //    Select Case app
        //    //        Case controllers.workgroup.App_Admin
        //    //            Dim lstMenu = New adminMenuItems
        //    //            For Each mnu In lstMenu
        //    //                Dim inAssign = (From p In AssignedModule Where p.ID = mnu.ID Select p).FirstOrDefault
        //    //                If inAssign IsNot Nothing Then
        //    //                    userMenus.Add(mnu)
        //    //                End If
        //    //            Next
        //    //        Case controllers.workgroup.App_Insurance
        //    //            If listBranchBlock.Count = 0 Then
        //    //                Return "You do not have a branch assignment"
        //    //            End If

        //    //            Dim brRec = dataservices.branches.getBranchByID(listBranchBlock(0).branchid)
        //    //            If brRec IsNot Nothing Then
        //    //                CurrentBranch = New dto.branch
        //    //                With CurrentBranch
        //    //                    .id = brRec.id
        //    //                    .areaid = brRec.areaid
        //    //                    .branch_code = brRec.branch_code
        //    //                    .branch_name = brRec.branch_name
        //    //                    .branch_id = brRec.branch_id
        //    //                    .branch_shortname = brRec.branch_shortname
        //    //                End With
        //    //            Else
        //    //                CurrentBranch = Nothing
        //    //            End If

        //    //            Dim blRec = dataservices.block.getBlockByID(listBranchBlock(0).blockid)
        //    //            If blRec IsNot Nothing Then
        //    //                CurrentBlock = New dto.block
        //    //                With CurrentBlock
        //    //                    .id = blRec.id
        //    //                    .branchGUID = blRec.branchGUID
        //    //                    .block_id = blRec.block_id
        //    //                    .block_code = blRec.block_code
        //    //                    .block_name = blRec.block_name
        //    //                    .block_shortname = blRec.block_shortname
        //    //                End With
        //    //            Else
        //    //                CurrentBlock = Nothing
        //    //            End If

        //    //            Dim lstMenu = New niMenuItems
        //    //            For Each mnu In lstMenu
        //    //                Dim inAssign = (From p In AssignedModule Where p.ID = mnu.ID Select p).FirstOrDefault
        //    //                If inAssign IsNot Nothing Then
        //    //                    userMenus.Add(mnu)
        //    //                End If
        //    //            Next
        //    //    End Select

        //    //    If userMenus.Count = 0 Then
        //    //        Return "You don't have any module assignment"
        //    //    End If

        //    //    userMenus.AddRange(New defaultMenuItems(False))

        //    //    UserID = usrRec.id
        //    //    UserName = usrRec.username
        //    //    FullName = usrRec.LastName & ", " & usrRec.FirstName & " " & usrRec.MiddleName
        //    //    EMail = usrRec.email

        //    //    Return Auth_Success
        //    //End If
        //    //Return "Invalid User Access"
        //        return "";
        //    }

        //    public static bool IsPwdMatch(Guid uid, string pwd)
        //    {
        //        var prec = dataservices.sids.getSID(uid);
        //        if (prec == null)
        //            return false;
        //        if (prec.authobj != genPassword(prec.authref, pwd))
        //            return false;
        //        return true;
        //    }

        //    private static string genPassword(string salt, string password)
        //    {
        //        string myString = password + salt;
        //        byte[] Data;
        //        Data = Encoding.ASCII.GetBytes(myString);
        //        SHA1Managed shaM = new SHA1Managed();
        //        byte[] resultHash = shaM.ComputeHash(Data);
        //        var resultHexString = "";
        //        StringBuilder sb = new StringBuilder();

        //        foreach (byte b in resultHash)
        //            sb.AppendFormat("{0:x2}", b);
        //            // resultHexString += Conversion.Hex(b);
        //        return sb.ToString();
        //    }

        //    private static string NewSalt()
        //    {
        //        RandomKeyGenerator KeyGen;
        //        int NumKeys;
        //        string RandomKey;

        //        NumKeys = 1;

        //        KeyGen = new RandomKeyGenerator();
        //        KeyGen.KeyLetters = "abcdefghijklmnopqrstuvwxyz";
        //        KeyGen.KeyNumbers = "0123456789";
        //        KeyGen.KeyChars = 10;
        //        RandomKey = KeyGen.Generate();
        //        return RandomKey.ToUpper();
        //    }

        //    private class RandomKeyGenerator
        //    {
        //        private string Key_Letters;
        //        private string Key_Numbers;
        //        private int Key_Chars;
        //        private char[] LettersArray;
        //        private char[] NumbersArray;

        //        /// <date>27072005</date><time>071924</time>
        //        ///         ''' <type>property</type>
        //        ///         ''' <summary>
        //        ///         ''' WRITE ONLY PROPERTY. HAS TO BE SET BEFORE CALLING GENERATE()
        //        ///         ''' </summary>
        //        protected internal string KeyLetters
        //        {
        //            set
        //            {
        //                Key_Letters = value;
        //            }
        //        }

        //        /// <date>27072005</date><time>071924</time>
        //        ///         ''' <type>property</type>
        //        ///         ''' <summary>
        //        ///         ''' WRITE ONLY PROPERTY. HAS TO BE SET BEFORE CALLING GENERATE()
        //        ///         ''' </summary>
        //        protected internal string KeyNumbers
        //        {
        //            set
        //            {
        //                Key_Numbers = value;
        //            }
        //        }

        //        /// <date>27072005</date><time>071924</time>
        //        ///         ''' <type>property</type>
        //        ///         ''' <summary>
        //        ///         ''' WRITE ONLY PROPERTY. HAS TO BE SET BEFORE CALLING GENERATE()
        //        ///         ''' </summary>
        //        protected internal int KeyChars
        //        {
        //            set
        //            {
        //                Key_Chars = value;
        //            }
        //        }

        //        /// <date>27072005</date><time>072344</time>
        //        ///         ''' <type>function</type>
        //        ///         ''' <summary>
        //        ///         ''' GENERATES A RANDOM STRING OF LETTERS AND NUMBERS.
        //        ///         ''' LETTERS CAN BE RANDOMLY CAPITAL OR SMALL.
        //        ///         ''' </summary>
        //        ///         ''' <returns type="String">RETURNS THE
        //        ///         '''         RANDOMLY GENERATED KEY</returns>
        //        public string Generate()
        //        {
        //            int i_key;
        //            float Random1;
        //            Int16 arrIndex;
        //            StringBuilder sb = new StringBuilder();
        //            string RandomLetter;

        //            // CONVERT LettersArray & NumbersArray TO CHARACTR ARRAYS
        //            LettersArray = Key_Letters.ToCharArray();
        //            NumbersArray = Key_Numbers.ToCharArray();

                    //for (i_key = 1; i_key <= Key_Chars; i_key++)
                    //{
                    //    // START THE CLOCK    - LAITH - 27/07/2005 18:01:18 -
                    //    VBMath.Randomize();
                    //    Random1 = VBMath.Rnd();
                    //    arrIndex = -1;
                    //    // IF THE VALUE IS AN EVEN NUMBER WE GENERATE A LETTER,
                    //    // OTHERWISE WE GENERATE A NUMBER  
                    //    // - LAITH - 27/07/2005 18:02:55 -
                    //    // THE NUMBER '111' WAS RANDOMLY CHOSEN. ANY NUMBER
                    //    // WILL DO, WE JUST NEED TO BRING THE VALUE
                    //    // ABOVE '0'     - LAITH - 27/07/2005 18:40:48 -
                    //    if ((System.Convert.ToInt32(Random1 * 111)) % 2 == 0)
                    //    {
                    //        // GENERATE A RANDOM INDEX IN THE LETTERS
                    //        // CHARACTER ARRAY   - LAITH - 27/07/2005 18:47:44 -
                    //        while (arrIndex < 0)
                    //            arrIndex = Convert.ToInt16(LettersArray.GetUpperBound(0)
                    //             * Random1);
                    //        RandomLetter = LettersArray[arrIndex];
                    //        // CREATE ANOTHER RANDOM NUMBER. IF IT IS ODD,
                    //        // WE CAPITALIZE THE LETTER
                    //        // - LAITH - 27/07/2005 18:55:59 -
                    //        if ((System.Convert.ToInt32(arrIndex * Random1 * 99)) % 2 != 0)
                    //        {
                    //            RandomLetter = LettersArray[arrIndex].ToString();
                    //            RandomLetter = RandomLetter.ToUpper();
                    //        }
                    //        sb.Append(RandomLetter);
                    //    }
                    //    else
                    //    {
                    //        // GENERATE A RANDOM INDEX IN THE NUMBERS
                    //        // CHARACTER ARRAY   - LAITH - 27/07/2005 18:47:44 -
                    //        while (arrIndex < 0)
                    //            arrIndex = Convert.ToInt16(NumbersArray.GetUpperBound(0)
                    //              * Random1);
                    //        sb.Append(NumbersArray[arrIndex]);
                    //    }
                    //}
            //        return sb.ToString();
            //    }
            //}
        }
    }
}
