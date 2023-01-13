unction EANCodeBIN(strEANCode: string): string;

var

  I : Integer;

  str, strAux, StrBinCode, StrCodigo : String;

begin

  strEANCode := Trim(strEANCode);

  strAux := strEANCode;

  If (strAux.Length <> 13) And (strAux.Length <> 8) Then

    Exception.Create('Código EAN Inválido');

 

  for  I := 0 to strEANCode.Length - 1 do

    if (strAux.Chars[I].ToString < '0') or (strAux.Chars[I].ToString > '9') then

      Exception.Create('Caracter Inválidos no EAN');

 

  If (strAux.Length = 13) Then

  begin

    strAux := Copy(strAux,2,Length(StrAux));

 

    Case Convert.ToInt32(Copy(strEANCode,1,1)) of

      0: StrCodigo := '000000';

      1: StrCodigo := '001011';

      2: StrCodigo := '001101';

      3: StrCodigo := '001110';

      4: StrCodigo := '010011';

      5: StrCodigo := '011001';

      6: StrCodigo := '011100';

      7: StrCodigo := '010101';

      8: StrCodigo := '010110';

      9: StrCodigo := '011010';

    end;

  end

  else

      StrCodigo := '0000';

 

  StrBinCode := '000101';

  For I := 1 To (Length(strAux) div 2) do

    Case Convert.ToInt32(Copy(strAux, I, 1)) of

      0:

        begin

          if Copy(StrCodigo, I, 1) = '0' then

            StrBinCode := StrBinCode + '0001101'

          else

            StrBinCode := StrBinCode + '0100111';

        end;

      1:

        begin

          if Copy(StrCodigo, I, 1) = '0' then

            StrBinCode := StrBinCode + '0011001'

          else

            StrBinCode := StrBinCode + '0110011';

        end;

      2:

        begin

          if Copy(StrCodigo, I, 1) = '0' then

            StrBinCode := StrBinCode + '0010011'

          else

            StrBinCode := StrBinCode + '0011011';

        end;

      3:

        begin

          if Copy(StrCodigo, I, 1) = '0' then

            StrBinCode := StrBinCode + '0111101'

          else

            StrBinCode := StrBinCode + '0100001';

        end;

      4:

        begin

          if Copy(StrCodigo, I, 1) = '0' then

            StrBinCode := StrBinCode + '0100011'

          else

            StrBinCode := StrBinCode + '0011101';

        end;

      5:

        begin

          if Copy(StrCodigo, I, 1) = '0' then

            StrBinCode := StrBinCode + '0110001'

          else

            StrBinCode := StrBinCode + '0111001';

        end;

      6:

        begin

          if Copy(StrCodigo, I, 1) = '0' then

            StrBinCode := StrBinCode + '0101111'

          else

            StrBinCode := StrBinCode + '0000101';

        end;

      7:

        begin

          if Copy(StrCodigo, I, 1) = '0' then

            StrBinCode := StrBinCode + '0111011'

          else

            StrBinCode := StrBinCode + '0010001';

        end;

      8:

        begin

          if Copy(StrCodigo, I, 1) = '0' then

            StrBinCode := StrBinCode + '0110111'

          else

            StrBinCode := StrBinCode + '0001001';

        end;

      9:

        begin

          if Copy(StrCodigo, I, 1) = '0' then

            StrBinCode := StrBinCode + '0001011'

          else

            StrBinCode := StrBinCode + '0010111';

        end;

    end;

    StrBinCode := StrBinCode + '01010';

 

    for I := (Length(strAux) div 2 + 1) To Length(strAux) do

      case Convert.ToInt32(Copy(strAux, I, 1)) of

        0 : StrBinCode := StrBinCode + '1110010';

        1 : StrBinCode := StrBinCode + '1100110';

        2 : StrBinCode := StrBinCode + '1101100';

        3 : StrBinCode := StrBinCode + '1000010';

        4 : StrBinCode := StrBinCode + '1011100';

        5 : StrBinCode := StrBinCode + '1001110';

        6 : StrBinCode := StrBinCode + '1010000';

        7 : StrBinCode := StrBinCode + '1000100';

        8 : StrBinCode := StrBinCode + '1001000';

        9 : StrBinCode := StrBinCode + '1110100';

      end;

 

      StrBinCode := StrBinCode + '101000';

 

      EANCodeBIN := StrBinCode;

    end;

 