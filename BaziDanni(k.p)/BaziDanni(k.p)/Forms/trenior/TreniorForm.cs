using BaziDanni_k.p_.Forms.Common;
using BaziDanni_k.p_.Repositories.trenior;

namespace BaziDanni_k.p_.Forms.trenior;

public sealed class TreniorForm(string cs)
    : EntityManagementForm("Управление: TRENIOR", new TreniorRepository(cs), "N_trenior", "N_trenior", "Ime_trenior", "N_sport", "Telefon_trenior");
