using BaziDanni_k.p_.Repositories.Common;

namespace BaziDanni_k.p_.Repositories.chlen;

public sealed class ChlenRepository(string cs) : GenericOracleRepository(cs, "chlen", "N_chlen", "N_chlen", "Ime_chlen", "EGN", "Telefon", "Adres");
