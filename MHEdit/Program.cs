using MHEdit.DAO;


if (args.Length >= 4)
{
    if (args[0].Equals("1J") || args[0].Equals("1U"))
    {
        MH1DAO DAO = new MH1DAO();
        DAO.SetGame(args[0]);
        if (args[1].Equals("-d", StringComparison.OrdinalIgnoreCase))
        {
            DAO.DumpData(args[2], args[3]);
        }
        else if (args[1].Equals("-i", StringComparison.OrdinalIgnoreCase))
        {
            DAO.LoadData(args[2], args[3]);
        }
    }
    else if (args[0].Equals("NAFU") || args[0].Equals("EUFU") || args[0].Equals("P2G"))
    {
        P2GDAO DAO = new P2GDAO();
        DAO.SetGame(args[0]);
        if (args[1].Equals("-d", StringComparison.OrdinalIgnoreCase))
        {
            DAO.DumpData(args[2], args[3]);
        }
        else if (args[1].Equals("-i", StringComparison.OrdinalIgnoreCase))
        {
            DAO.LoadData(args[2], args[3]);
        }
    }
}