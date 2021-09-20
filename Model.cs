using System.Collections.Generic;
namespace Kontrolna
{
    public class Model
    {
        public virtual void MoveLeft(ref long[][] sheet)
        {
            int sheet_height = sheet.GetLength(0);
            int sheet_width = sheet[0].GetLength(0);



            for (int i = 0; i < sheet_height; i++)
            {
            rep:
                for(int j = 0; j < sheet_width; j++)
                {
                    if (j + 1 < sheet_width && (sheet[i][j + 1] != 0 && sheet[i][j] == 0 || sheet[i][j + 1] == sheet[i][j] && sheet[i][j] != 0))
                    {
                        if (sheet[i][j + 1] == sheet[i][j])
                            sheet[i][j] += sheet[i][j + 1];
                        else 
                            sheet[i][j] = sheet[i][j + 1];
                        sheet[i][j + 1] = 0;
                        goto rep;
                    }
                }
            }
        }
        public virtual void MoveRight(ref long[][] sheet)
        {
            int sheet_height = sheet.GetLength(0);
            int sheet_width = sheet[0].GetLength(0);
            for (int i = 0; i < sheet_height; i++)
            {
            rep:
                for (int j = sheet_width - 1; j >= 0; j--)
                {
                    if (j - 1 >= 0 && (sheet[i][j - 1] != 0 && sheet[i][j] == 0 || sheet[i][j - 1] == sheet[i][j] && sheet[i][j] != 0))
                    {
                        if (sheet[i][j - 1] == sheet[i][j])
                            sheet[i][j] += sheet[i][j - 1];
                        else
                            sheet[i][j] = sheet[i][j - 1];
                        sheet[i][j - 1] = 0;
                        goto rep;
                    }
                }
            }
        }
        public virtual void MoveUp(ref long[][] sheet)
        {
            int sheet_height = sheet.GetLength(0);
            int sheet_width = sheet[0].GetLength(0);
            for (int j = 0; j < sheet_width; j++)
            {
            rep:
                for (int i = 0; i < sheet_height; i++)
                {
                    if (i + 1 < sheet_height && (sheet[i + 1][j] != 0 && sheet[i][j] == 0 ||  sheet[i + 1][j] == sheet[i][j] && sheet[i][j] != 0))
                    {
                        if(sheet[i + 1][j] == sheet[i][j])
                            sheet[i][j] += sheet[i + 1][j];
                        else
                            sheet[i][j] = sheet[i + 1][j];
                        sheet[i + 1][j] = 0;
                        goto rep;
                    }
                }
                
            }
        }
        public virtual void MoveDown(ref long[][] sheet)
        {
            int sheet_height = sheet.GetLength(0);
            int sheet_width = sheet[0].GetLength(0);
            for (int j = 0; j < sheet_width; j++)
            {
            rep:
                for (int i = sheet_height - 1; i >= 0; i--)
                {
                    if (i - 1 >=0 && (sheet[i - 1][j] != 0 && sheet[i][j] == 0 || sheet[i - 1][j] == sheet[i][j] && sheet[i][j] != 0))
                    {
                        if (sheet[i - 1][j] == sheet[i][j])
                            sheet[i][j] += sheet[i - 1][j];
                        else
                            sheet[i][j] = sheet[i - 1][j];
                        sheet[i - 1][j] = 0;
                        goto rep;
                    }
                }
            }
        }

        public virtual bool CanMoveLeft(long[][] sheet)
        {
            int sheet_height = sheet.GetLength(0);
            int sheet_width = sheet[0].GetLength(0);
            for (int i = 0; i < sheet_height; i++)
            {
                for (int j = 0; j < sheet_width; j++)
                {
                    if (j + 1 < sheet_width && (sheet[i][j + 1] != 0 && sheet[i][j] == 0 ||sheet[i][j + 1] == sheet[i][j] && sheet[i][j] != 0))
                        return true;
                }
            }
            return false;
        }
        public virtual bool CanMoveRight(long[][] sheet)
        {
            int sheet_height = sheet.GetLength(0);
            int sheet_width = sheet[0].GetLength(0);
            for (int i = 0; i < sheet_height; i++)
            {
                for (int j = sheet_width - 1; j >= 0; j--)
                {
                    if (j - 1 >= 0 && (sheet[i][j - 1] != 0 && sheet[i][j] == 0 || sheet[i][j - 1] == sheet[i][j] && sheet[i][j] != 0))
                        return true;
                }
            }
            return false;
        }
        public virtual bool CanMoveUp(long[][] sheet)
        {
            int sheet_height = sheet.GetLength(0);
            int sheet_width = sheet[0].GetLength(0);
            for (int j = 0; j < sheet_width; j++)
            {
                for (int i = 0; i < sheet_height; i++)
                {
                    if (i + 1 < sheet_height && (sheet[i + 1][j] != 0 && sheet[i][j] == 0 || sheet[i + 1][j] == sheet[i][j] && sheet[i][j] != 0))
                        return true;
                }
            }
            return false;
        }
        public virtual bool CanMoveDown(long[][] sheet)
        {
            int sheet_height = sheet.GetLength(0);
            int sheet_width = sheet[0].GetLength(0);
            for (int j = 0; j < sheet_width; j++)
            {
                for (int i = sheet_height - 1; i >= 0; i--)
                {
                    if (i - 1 >= 0 && (sheet[i - 1][j] != 0 && sheet[i][j] == 0 || sheet[i - 1][j] == sheet[i][j] && sheet[i][j] != 0))
                        return true;
                }
            }
            return false;
        }

        public virtual bool HasFreeCell(long[][] sheet)
        {
            int sheet_height = sheet.GetLength(0);
            int sheet_width = sheet[0].GetLength(0);
            for (int i = 0; i < sheet_height; i++)
                for (int j = 0; j < sheet_width; j++)
                    if (sheet[i][j] == 0) return true;
            return false;
        }
        public virtual List<(int, int)> GetFreeCells(long[][] sheet)
        {
            List<(int, int)> cells = new List<(int, int)>();
            int sheet_height = sheet.GetLength(0);
            int sheet_width = sheet[0].GetLength(0);
            for (int i = 0; i < sheet_height; i++)
                for (int j = 0; j < sheet_width; j++)
                    if(sheet[i][j]==0)cells.Add((i, j));
            return cells;
        }

        public virtual bool CanMove(long[][] sheet)
        {
            return HasFreeCell(sheet) || CanMoveLeft(sheet) || CanMoveRight(sheet) || CanMoveDown(sheet) || CanMoveUp(sheet);
        }

        public virtual void Clear(ref long[][] sheet)
        {
            int sheet_height = sheet.GetLength(0);
            int sheet_width = sheet[0].GetLength(0);
            for (int i = 0; i < sheet_height; i++)
                for (int j = 0; j < sheet_width; j++)
                    sheet[i][j] = 0;
        }

        public virtual bool Exists(long[][] sheet,long value)
        {
            int sheet_height = sheet.GetLength(0);
            int sheet_width = sheet[0].GetLength(0);
            for (int i = 0; i < sheet_height; i++)
                for (int j = 0; j < sheet_width; j++)
                    if(sheet[i][j] == value)return true;
            return false;
        }

        public virtual long Sum(long[][] sheet)
        {
            long res = 0;
            int sheet_height = sheet.GetLength(0);
            int sheet_width = sheet[0].GetLength(0);
            for (int i = 0; i < sheet_height; i++)
                for (int j = 0; j < sheet_width; j++)
                    res += sheet[i][j];
            return res;
        }

    }
}
