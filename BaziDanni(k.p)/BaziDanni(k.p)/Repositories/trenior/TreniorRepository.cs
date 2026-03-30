using BaziDanni_k.p_.Repositories.Common;

namespace BaziDanni_k.p_.Repositories.trenior;

public sealed class TreniorRepository(string cs) : GenericOracleRepository(cs, "trenior", "N_trenior", "N_trenior", "Ime_trenior", "N_sport", "Telefon_trenior");
