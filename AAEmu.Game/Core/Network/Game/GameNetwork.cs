using System;
using System.Net;
using AAEmu.Commons.Network.Type;
using AAEmu.Commons.Utils;
using AAEmu.Game.Core.Packets.C2G;
using AAEmu.Game.Core.Packets.Proxy;
using AAEmu.Game.Models;
using NLog;

namespace AAEmu.Game.Core.Network.Game
{
    public class GameNetwork : Singleton<GameNetwork>
    {
        private Server _server;
        private GameProtocolHandler _handler;
        private static Logger _log = LogManager.GetCurrentClassLogger();

        private GameNetwork()
        {
            _handler = new GameProtocolHandler();

            // World
            RegisterPacket(CSOffsets.X2EnterWorldPacket, 1, typeof(X2EnterWorldPacket)); // level = 1
            //RegisterPacket(CSOffsets.CSTodayAssignmentPacket, 5, typeof(CSTodayAssignmentPacket));
            //RegisterPacket(CSOffsets.CSRequestSkipClientDrivenIndunPacket, 5, typeof(CSRequestSkipClientDrivenIndunPacket));
            //RegisterPacket(CSOffsets.CSRemoveClientNpcPacket, 5, typeof(CSRemoveClientNpcPacket));
            RegisterPacket(CSOffsets.CSMoveUnitPacket, 5, typeof(CSMoveUnitPacket));
            RegisterPacket(CSOffsets.CSCofferInteractionPacket, 5, typeof(CSCofferInteractionPacket));
            //RegisterPacket(CSOffsets.CSRequestCommonFarmListPacket, 5, typeof(CSRequestCommonFarmListPacket));
            RegisterPacket(CSOffsets.CSChallengeDuelPacket, 5, typeof(CSChallengeDuelPacket));
            RegisterPacket(CSOffsets.CSStartDuelPacket, 5, typeof(CSStartDuelPacket));
            //RegisterPacket(CSOffsets.CSHeroRankingListPacket, 5, typeof(CSHeroRankingListPacket));

            RegisterPacket(CSOffsets.CSUnknownPacket_0x186, 1, typeof(CSUnknownPacket_0x186)); // level = 1
            //RegisterPacket(CSOffsets.CSHeroCandidateListPacket, 5, typeof(CSHeroCandidateListPacket));
            //RegisterPacket(CSOffsets.CSHeroAbstainPacket, 5, typeof(CSHeroAbstainPacket));
            //RegisterPacket(CSOffsets.CSHeroVotingPacket, 5, typeof(CSHeroVotingPacket));
            RegisterPacket(CSOffsets.CSConvertItemLookPacket, 5, typeof(CSConvertItemLookPacket));
            //RegisterPacket(CSOffsets.CSConvertItemLook2Packet, 5, typeof(CSConvertItemLook2Packet));
            RegisterPacket(CSOffsets.CSSetPingPosPacket, 5, typeof(CSSetPingPosPacket));
            //RegisterPacket(CSOffsets.CSUpdateExploredRegionPacket, 5, typeof(CSUpdateExploredRegionPacket));
            //RegisterPacket(CSOffsets.CSIcsMoneyRequestPacket, 5, typeof(CSIcsMoneyRequestPacket));
            RegisterPacket(CSOffsets.CSPremiumServiceBuyPacket, 5, typeof(CSPremiumServiceBuyPacket));
            //RegisterPacket(CSOffsets.CSSetVisiblePremiumServicePacket, 5, typeof(CSSetVisiblePremiumServicePacket));
            //RegisterPacket(CSOffsets.CSAddReputationPacket, 5, typeof(CSAddReputationPacket));
            //RegisterPacket(CSOffsets.CSUnknown0x80Packet, 5, typeof(CSUnknown0x80Packet));
            //RegisterPacket(CSOffsets.CSGetResidentDescPacket, 5, typeof(CSGetResidentDescPacket));
            //RegisterPacket(CSOffsets.CSRefreshResidentMembersPacket, 5, typeof(CSRefreshResidentMembersPacket));
            //RegisterPacket(CSOffsets.CSGetResidentZoneListPacket, 5, typeof(CSGetResidentZoneListPacket));
            //RegisterPacket(CSOffsets.CSResidentFireNuonsArrowPacket, 5, typeof(CSResidentFireNuonsArrowPacket));
            //RegisterPacket(CSOffsets.CSUseBlessUthstinInitStatsPacket, 5, typeof(CSUseBlessUthstinInitStatsPacket));
            //RegisterPacket(CSOffsets.CSUseBlessUthstinExtendMaxStatsPacket, 5, typeof(CSUseBlessUthstinExtendMaxStatsPacket));
            //RegisterPacket(CSOffsets.CSBlessUthstinUseApplyStatsItemPacket, 5, typeof(CSBlessUthstinUseApplyStatsItemPacket));
            //RegisterPacket(CSOffsets.CSBlessUthstinApplyStatsPacket, 5, typeof(CSBlessUthstinApplyStatsPacket));
            //RegisterPacket(CSOffsets.CSEventCenterAddAttendancePacket, 5, typeof(CSEventCenterAddAttendancePacket));
            //RegisterPacket(CSOffsets.CSRequestGameEventInfoPacket, 5, typeof(CSRequestGameEventInfoPacket));
            //RegisterPacket(CSOffsets.CSUnknown0x0cbPacket, 5, typeof(CSUnknown0x0cbPacket));
            //RegisterPacket(CSOffsets.CSUnknown0x0aPacket, 5, typeof(CSUnknown0x0aPacket));
            RegisterPacket(CSOffsets.CSChangeMateNamePacket, 5, typeof(CSChangeMateNamePacket));
            //RegisterPacket(CSOffsets.CSSendNationMemberCountListPacket, 5, typeof(CSSendNationMemberCountListPacket));
            //RegisterPacket(CSOffsets.CSNationSendExpeditionImmigrationAcceptRejectPacket, 5, typeof(CSNationSendExpeditionImmigrationAcceptRejectPacket));
            //RegisterPacket(CSOffsets.CSSendExpeditionImmigrationListPacket, 5, typeof(CSSendExpeditionImmigrationListPacket));
            //RegisterPacket(CSOffsets.CSSendRelationFriendPacket, 5, typeof(CSSendRelationFriendPacket));
            //RegisterPacket(CSOffsets.CSSendRelationVotePacket, 5, typeof(CSSendRelationVotePacket));
            //RegisterPacket(CSOffsets.CSSendNationInfoSetPacket, 5, typeof(CSSendNationInfoSetPacket));
            //RegisterPacket(CSOffsets.CSRankCharacterPacket, 5, typeof(CSRankCharacterPacket));
            //RegisterPacket(CSOffsets.CSRankSnapshotPacket, 5, typeof(CSRankSnapshotPacket));
            //RegisterPacket(CSOffsets.CSHeroRequestRankDataPacket, 5, typeof(CSHeroRequestRankDataPacket));
            //RegisterPacket(CSOffsets.CSGetRankerInformationPacket, 5, typeof(CSGetRankerInformationPacket));
            //RegisterPacket(CSOffsets.CSRequestRankerAppearancePacket, 5, typeof(CSRequestRankerAppearancePacket));
            //RegisterPacket(CSOffsets.CSRequestSecondPassKeyTablesPacket, 5, typeof(CSRequestSecondPassKeyTablesPacket));
            //RegisterPacket(CSOffsets.CSCreateSecondPassPacket, 5, typeof(CSCreateSecondPassPacket));
            //RegisterPacket(CSOffsets.CSChangeSecondPassPacket, 5, typeof(CSChangeSecondPassPacket));
            //RegisterPacket(CSOffsets.CSClearSecondPassPacket, 5, typeof(CSClearSecondPassPacket));
            //RegisterPacket(CSOffsets.CSCheckSecondPassPacket, 5, typeof(CSCheckSecondPassPacket));
            RegisterPacket(CSOffsets.CSReplyImprisonOrTrialPacket, 5, typeof(CSReplyImprisonOrTrialPacket));
            RegisterPacket(CSOffsets.CSSkipFinalStatementPacket, 5, typeof(CSSkipFinalStatementPacket));
            RegisterPacket(CSOffsets.CSReplyInviteJuryPacket, 5, typeof(CSReplyInviteJuryPacket));
            RegisterPacket(CSOffsets.CSJurySummonedPacket, 5, typeof(CSJurySummonedPacket));
            RegisterPacket(CSOffsets.CSJuryEndTestimonyPacket, 5, typeof(CSJuryEndTestimonyPacket));
            RegisterPacket(CSOffsets.CSCancelTrialPacket, 5, typeof(CSCancelTrialPacket));
            //RegisterPacket(CSOffsets.CSJurySentencePacket, 5, typeof(CSJurySentencePacket));
            RegisterPacket(CSOffsets.CSReportCrimePacket, 5, typeof(CSReportCrimePacket));
            RegisterPacket(CSOffsets.CSRequestJuryWaitingNumberPacket, 5, typeof(CSRequestJuryWaitingNumberPacket));
            //RegisterPacket(CSOffsets.CSRequestSetBountyPacket, 5, typeof(CSRequestSetBountyPacket));
            //RegisterPacket(CSOffsets.CSUpdateBountyPacket, 5, typeof(CSUpdateBountyPacket));
            //RegisterPacket(CSOffsets.CSTrialReportBadUserPacket, 5, typeof(CSTrialReportBadUserPacket));
            //RegisterPacket(CSOffsets.CSTrialRequestBadUserListPacket, 5, typeof(CSTrialRequestBadUserListPacket));
            //RegisterPacket(CSOffsets.CSsUnknown0x146Packet, 5, typeof(CSsUnknown0x146Packet));
            //RegisterPacket(CSOffsets.CSSendUserMusicPacket, 5, typeof(CSSendUserMusicPacket));
            //RegisterPacket(CSOffsets.CSSaveUserMusicNotesPacket, 5, typeof(CSSaveUserMusicNotesPacket));
            //RegisterPacket(CSOffsets.CSRequestMusicNotesPacket, 5, typeof(CSRequestMusicNotesPacket));
            //RegisterPacket(CSOffsets.CSPauseUserMusicPacket, 5, typeof(CSPauseUserMusicPacket));
            //RegisterPacket(CSOffsets.CSUnknown0x5ePacket, 5, typeof(CSUnknown0x5ePacket));
            //RegisterPacket(CSOffsets.CSBagHandleSelectiveItemsPacket, 5, typeof(CSBagHandleSelectiveItemsPacket));
            RegisterPacket(CSOffsets.CSSkillControllerStatePacket, 5, typeof(CSSkillControllerStatePacket));
            RegisterPacket(CSOffsets.CSMountMatePacket, 5, typeof(CSMountMatePacket));
            RegisterPacket(CSOffsets.CSLeaveWorldPacket, 5, typeof(CSLeaveWorldPacket));
            RegisterPacket(CSOffsets.CSCancelLeaveWorldPacket, 5, typeof(CSCancelLeaveWorldPacket));
            RegisterPacket(CSOffsets.CSIdleStatusPacket, 5, typeof(CSIdleStatusPacket));
            //RegisterPacket(CSOffsets.CSChangeClientNpcTargetPacket, 5, typeof(CSChangeClientNpcTargetPacket));
            RegisterPacket(CSOffsets.CSCompletedCinemaPacket, 5, typeof(CSCompletedCinemaPacket));
            //RegisterPacket(CSOffsets.CSCheckDemoModePacket, 5, typeof(CSCheckDemoModePacket));
            //RegisterPacket(CSOffsets.CSDemoCharResetPacket, 5, typeof(CSDemoCharResetPacket));
            RegisterPacket(CSOffsets.CSConsoleCmdUsedPacket, 5, typeof(CSConsoleCmdUsedPacket));
            RegisterPacket(CSOffsets.CSEditorGameModePacket, 5, typeof(CSEditorGameModePacket));
            //RegisterPacket(CSOffsets.CSInteractGimmickPacket, 5, typeof(CSInteractGimmickPacket));
            //RegisterPacket(CSOffsets.CSWorldRaycastingPacket, 5, typeof(CSWorldRaycastingPacket));
            //RegisterPacket(CSOffsets.CSOpenExpeditionImmigrationRequestPacket, 5, typeof(CSOpenExpeditionImmigrationRequestPacket));
            //RegisterPacket(CSOffsets.CSNationGetNationNamePacket, 5, typeof(CSNationGetNationNamePacket));
            RegisterPacket(CSOffsets.CSRefreshInCharacterListPacket, 5, typeof(CSRefreshInCharacterListPacket));
            RegisterPacket(CSOffsets.CSDeleteCharacterPacket, 5, typeof(CSDeleteCharacterPacket));
            RegisterPacket(CSOffsets.CSCancelCharacterDeletePacket, 5, typeof(CSCancelCharacterDeletePacket));
            RegisterPacket(CSOffsets.CSSelectCharacterPacket, 5, typeof(CSSelectCharacterPacket));
            RegisterPacket(CSOffsets.CSCharacterConnectionRestrictPacket, 5, typeof(CSCharacterConnectionRestrictPacket));
            RegisterPacket(CSOffsets.CSNotifyInGamePacket, 5, typeof(CSNotifyInGamePacket));
            RegisterPacket(CSOffsets.CSNotifyInGameCompletedPacket, 5, typeof(CSNotifyInGameCompletedPacket));
            RegisterPacket(CSOffsets.CSChangeTargetPacket, 5, typeof(CSChangeTargetPacket));
            //RegisterPacket(CSOffsets.CSUnknown0x8bPacket, 5, typeof(CSUnknown0x8bPacket));
            //RegisterPacket(CSOffsets.CSGetSiegeAuctionBidCurrencyPacket, 5, typeof(CSGetSiegeAuctionBidCurrencyPacket));
            RegisterPacket(CSOffsets.CSResurrectCharacterPacket, 5, typeof(CSResurrectCharacterPacket));
            RegisterPacket(CSOffsets.CSCriminalLockedPacket, 5, typeof(CSCriminalLockedPacket));
            RegisterPacket(CSOffsets.CSExpressEmotionPacket, 5, typeof(CSExpressEmotionPacket));
            RegisterPacket(CSOffsets.CSUnhangPacket, 5, typeof(CSUnhangPacket));
            RegisterPacket(CSOffsets.CSChangeAppellationPacket, 5, typeof(CSChangeAppellationPacket));
            RegisterPacket(CSOffsets.CSStartedCinemaPacket, 5, typeof(CSStartedCinemaPacket));
            
            RegisterPacket(CSOffsets.CSHgResponsePacket, 1, typeof(CSHgResponsePacket)); // level = 1
            RegisterPacket(CSOffsets.CSBroadcastVisualOptionPacket, 5, typeof(CSBroadcastVisualOptionPacket));
            RegisterPacket(CSOffsets.CSBroadcastOpenEquipInfoPacket, 5, typeof(CSBroadcastOpenEquipInfoPacket));
            RegisterPacket(CSOffsets.CSRestrictCheckPacket, 5, typeof(CSRestrictCheckPacket));
            //RegisterPacket(CSOffsets.CSIcsMenuListRequestPacket, 5, typeof(CSIcsMenuListRequestPacket));
            //RegisterPacket(CSOffsets.CSIcsGoodsListRequestPacket, 5, typeof(CSIcsGoodsListRequestPacket));
            //RegisterPacket(CSOffsets.CSIcsBuyGoodRequestPacket, 5, typeof(CSIcsBuyGoodRequestPacket));
            RegisterPacket(CSOffsets.CSPremiumServiceMsgPacket, 5, typeof(CSPremiumServiceMsgPacket));
            //RegisterPacket(CSOffsets.CSProtectSensitiveOperationPacket, 5, typeof(CSProtectSensitiveOperationPacket));
            //RegisterPacket(CSOffsets.CSCancelSensitiveOperationVerifyPacket, 5, typeof(CSCancelSensitiveOperationVerifyPacket));
            //RegisterPacket(CSOffsets.CSAntibotDataPacket, 5, typeof(CSAntibotDataPacket));
            //RegisterPacket(CSOffsets.CSBuyAaPointPacket, 5, typeof(CSBuyAaPointPacket));
            //RegisterPacket(CSOffsets.CSRequestTencentFatigueInfoPacket, 5, typeof(CSRequestTencentFatigueInfoPacket));
            RegisterPacket(CSOffsets.CSPremiumServiceListPacket, 5, typeof(CSPremiumServiceListPacket));
            //RegisterPacket(CSOffsets.CSRequestSysInstanceIndexPacket, 5, typeof(CSRequestSysInstanceIndexPacket));
            //RegisterPacket(CSOffsets.CSQuitResponsePacket, 5, typeof(CSQuitResponsePacket));
            RegisterPacket(CSOffsets.CSSecurityReportPacket, 5, typeof(CSSecurityReportPacket));
            //RegisterPacket(CSOffsets.CSEnprotectStubCallResponsePacket, 5, typeof(CSEnprotectStubCallResponsePacket));
            //RegisterPacket(CSOffsets.CSRepresentCharacterPacket, 5, typeof(CSRepresentCharacterPacket));
            //RegisterPacket(CSOffsets.CSPacketUnknown0x0aaPacket, 5, typeof(CSPacketUnknown0x0aaPacket));
            RegisterPacket(CSOffsets.CSPacketUnknown0x166Packet, 5, typeof(CSPacketUnknown0x166Packet));
            RegisterPacket(CSOffsets.CSCreateCharacterPacket, 5, typeof(CSCreateCharacterPacket));
            RegisterPacket(CSOffsets.CSEditCharacterPacket, 5, typeof(CSEditCharacterPacket));
            RegisterPacket(CSOffsets.CSBroadcastVisualOption_0_Packet, 5, typeof(CSBroadcastVisualOption_0_Packet));
            RegisterPacket(CSOffsets.CSSpawnCharacterPacket, 5, typeof(CSSpawnCharacterPacket));
            // пакет для дешифрации
            RegisterPacket(CSOffsets.CSRsaencryptAeskeyXorkeyPacket, 1, typeof(CSRsaencryptAeskeyXorkeyPacket));
            //
            RegisterPacket(CSOffsets.CSNotifySubZonePacket, 5, typeof(CSNotifySubZonePacket));
            RegisterPacket(CSOffsets.CSSaveTutorialPacket, 5, typeof(CSSaveTutorialPacket));
            RegisterPacket(CSOffsets.CSRequestUIDataPacket, 5, typeof(CSRequestUIDataPacket));
            RegisterPacket(CSOffsets.CSSaveUIDataPacket, 5, typeof(CSSaveUIDataPacket));
            //RegisterPacket(CSOffsets.CSBeautyshopDataPacket, 5, typeof(CSBeautyshopDataPacket));
            //RegisterPacket(CSOffsets.CSDominionUpdateTaxratePacket, 5, typeof(CSDominionUpdateTaxratePacket));
            //RegisterPacket(CSOffsets.CSDominionUpdateNationalTaxratePacket, 5, typeof(CSDominionUpdateNationalTaxratePacket));
            //RegisterPacket(CSOffsets.CSRequestCharacterBriefPacket, 5, typeof(CSRequestCharacterBriefPacket));
            //RegisterPacket(CSOffsets.CSExpeditionCreatePacket, 5, typeof(CSExpeditionCreatePacket));
            //RegisterPacket(CSOffsets.CSExpeditionChangeRolePolicyPacket, 5, typeof(CSExpeditionChangeRolePolicyPacket));
            //RegisterPacket(CSOffsets.CSExpeditionMemberRolePacket, 5, typeof(CSExpeditionMemberRolePacket));
            //RegisterPacket(CSOffsets.CSExpeditionChangeOwnerPacket, 5, typeof(CSExpeditionChangeOwnerPacket));
            //RegisterPacket(CSOffsets.CSChangeNationOwnerPacket, 5, typeof(CSChangeNationOwnerPacket));
            //RegisterPacket(CSOffsets.CSRenameFactionPacket, 5, typeof(CSRenameFactionPacket));
            //RegisterPacket(CSOffsets.CSExpeditionDismissPacket, 5, typeof(CSExpeditionDismissPacket));
            //RegisterPacket(CSOffsets.CSExpeditionInvitePacket, 5, typeof(CSExpeditionInvitePacket));
            //RegisterPacket(CSOffsets.CSExpeditionLeavePacket, 5, typeof(CSExpeditionLeavePacket));
            //RegisterPacket(CSOffsets.CSExpeditionKickPacket, 5, typeof(CSExpeditionKickPacket));
            //RegisterPacket(CSOffsets.CSExpeditionBeginnerJoinPacket, 5, typeof(CSExpeditionBeginnerJoinPacket));
            //RegisterPacket(CSOffsets.CSDeclareExpeditionWarPacket, 5, typeof(CSDeclareExpeditionWarPacket));
            //RegisterPacket(CSOffsets.CSFactionGetDeclarationMoneyPacket, 5, typeof(CSFactionGetDeclarationMoneyPacket));
            //RegisterPacket(CSOffsets.CSUnknown0x0a3Packet, 5, typeof(CSUnknown0x0a3Packet));
            //RegisterPacket(CSOffsets.CSFactionGetExpeditionWarHistoryPacket, 5, typeof(CSFactionGetExpeditionWarHistoryPacket));
            //RegisterPacket(CSOffsets.CSFactionCancelProtectionPacket, 5, typeof(CSFactionCancelProtectionPacket));
            RegisterPacket(CSOffsets.CSFactionImmigrationInvitePacket, 5, typeof(CSFactionImmigrationInvitePacket));
            RegisterPacket(CSOffsets.CSFactionImmigrationInviteReplyPacket, 5, typeof(CSFactionImmigrationInviteReplyPacket));
            RegisterPacket(CSOffsets.CSFactionImmigrateToOriginPacket, 5, typeof(CSFactionImmigrateToOriginPacket));
            RegisterPacket(CSOffsets.CSFactionKickToOriginPacket, 5, typeof(CSFactionKickToOriginPacket));
            //RegisterPacket(CSOffsets.CSFactionMobilizationOrderPacket, 5, typeof(CSFactionMobilizationOrderPacket));
            //RegisterPacket(CSOffsets.CSFactionCheckExpeditionExpNextDayPacket, 5, typeof(CSFactionCheckExpeditionExpNextDayPacket));
            //RegisterPacket(CSOffsets.CSFactionSetExpeditionLevelUpPacket, 5, typeof(CSFactionSetExpeditionLevelUpPacket));
            //RegisterPacket(CSOffsets.CSFactionSetExpeditionMotdPacket, 5, typeof(CSFactionSetExpeditionMotdPacket));
            //RegisterPacket(CSOffsets.CSFactionSetMyExpeditionInterestPacket, 5, typeof(CSFactionSetMyExpeditionInterestPacket));
            //RegisterPacket(CSOffsets.CSUnknown0x60Packet, 5, typeof(CSUnknown0x60Packet));
            //RegisterPacket(CSOffsets.CSExpeditionReplyInvitationPacket, 5, typeof(CSExpeditionReplyInvitationPacket));
            RegisterPacket(CSOffsets.CSFamilyInviteMemberPacket, 5, typeof(CSFamilyInviteMemberPacket));
            RegisterPacket(CSOffsets.CSFamilyLeavePacket, 5, typeof(CSFamilyLeavePacket));
            RegisterPacket(CSOffsets.CSFamilyKickPacket, 5, typeof(CSFamilyKickPacket));
            RegisterPacket(CSOffsets.CSFamilyChangeTitlePacket, 5, typeof(CSFamilyChangeTitlePacket));
            RegisterPacket(CSOffsets.CSFamilyChangeOwnerPacket, 5, typeof(CSFamilyChangeOwnerPacket));
            //RegisterPacket(CSOffsets.CSFamilySetNamePacket, 5, typeof(CSFamilySetNamePacket));
            //RegisterPacket(CSOffsets.CSFamilySetContentPacket, 5, typeof(CSFamilySetContentPacket));
            //RegisterPacket(CSOffsets.CSFamilyOpenIncreaseMemberPacket, 5, typeof(CSFamilyOpenIncreaseMemberPacket));
            //RegisterPacket(CSOffsets.CSFamilyChangeMemberRolePacket, 5, typeof(CSFamilyChangeMemberRolePacket));
            RegisterPacket(CSOffsets.CSFamilyReplyInvitationPacket, 5, typeof(CSFamilyReplyInvitationPacket));
            RegisterPacket(CSOffsets.CSAddFriendPacket, 5, typeof(CSAddFriendPacket));
            RegisterPacket(CSOffsets.CSDeleteFriendPacket, 5, typeof(CSDeleteFriendPacket));
            RegisterPacket(CSOffsets.CSAddBlockedUserPacket, 5, typeof(CSAddBlockedUserPacket));
            RegisterPacket(CSOffsets.CSDeleteBlockedUserPacket, 5, typeof(CSDeleteBlockedUserPacket));
            RegisterPacket(CSOffsets.CSInviteAreaToTeamPacket, 5, typeof(CSInviteAreaToTeamPacket));
            RegisterPacket(CSOffsets.CSInviteToTeamPacket, 5, typeof(CSInviteToTeamPacket));
            RegisterPacket(CSOffsets.CSReplyToJoinTeamPacket, 5, typeof(CSReplyToJoinTeamPacket));
            RegisterPacket(CSOffsets.CSLeaveTeamPacket, 5, typeof(CSLeaveTeamPacket));
            RegisterPacket(CSOffsets.CSKickTeamMemberPacket, 5, typeof(CSKickTeamMemberPacket));
            RegisterPacket(CSOffsets.CSMakeTeamOwnerPacket, 5, typeof(CSMakeTeamOwnerPacket));
            //RegisterPacket(CSOffsets.CSConvertToRaidteamPacket, 5, typeof(CSConvertToRaidteamPacket));
            RegisterPacket(CSOffsets.CSMoveTeamMemberPacket, 5, typeof(CSMoveTeamMemberPacket));
            RegisterPacket(CSOffsets.CSDismissTeamPacket, 5, typeof(CSDismissTeamPacket));
            RegisterPacket(CSOffsets.CSSetTeamMemberRolePacket, 5, typeof(CSSetTeamMemberRolePacket));
            RegisterPacket(CSOffsets.CSSetOverHeadMarkerPacket, 5, typeof(CSSetOverHeadMarkerPacket));
            RegisterPacket(CSOffsets.CSAskRiskyTeamActionPacket, 5, typeof(CSAskRiskyTeamActionPacket));
            //RegisterPacket(CSOffsets.CSTeamAcceptHandOverOwnerPacket, 5, typeof(CSTeamAcceptHandOverOwnerPacket));
            //RegisterPacket(CSOffsets.CSTeamAcceptOwnerOfferPacket, 5, typeof(CSTeamAcceptOwnerOfferPacket));
            RegisterPacket(CSOffsets.CSChangeLootingRulePacket, 5, typeof(CSChangeLootingRulePacket));
            //RegisterPacket(CSOffsets.CSRenameCharacterPacket, 5, typeof(CSRenameCharacterPacket));
            RegisterPacket(CSOffsets.CSUpdateActionSlotPacket, 5, typeof(CSUpdateActionSlotPacket));
            RegisterPacket(CSOffsets.CSUsePortalPacket, 5, typeof(CSUsePortalPacket));
            RegisterPacket(CSOffsets.CSUpgradeExpertLimitPacket, 5, typeof(CSUpgradeExpertLimitPacket));
            RegisterPacket(CSOffsets.CSDowngradeExpertLimitPacket, 5, typeof(CSDowngradeExpertLimitPacket));
            RegisterPacket(CSOffsets.CSExpandExpertPacket, 5, typeof(CSExpandExpertPacket));
            //RegisterPacket(CSOffsets.CSEnterSysInstancePacket, 5, typeof(CSEnterSysInstancePacket));
            //RegisterPacket(CSOffsets.CSEndPortalInteractionPacket, 5, typeof(CSEndPortalInteractionPacket));
            RegisterPacket(CSOffsets.CSCreateShipyardPacket, 5, typeof(CSCreateShipyardPacket));
            RegisterPacket(CSOffsets.CSCreateHousePacket, 5, typeof(CSCreateHousePacket));
            //RegisterPacket(CSOffsets.CSLeaveBeautyshopPacket, 5, typeof(CSLeaveBeautyshopPacket));
            RegisterPacket(CSOffsets.CSConstructHouseTaxPacket, 5, typeof(CSConstructHouseTaxPacket));
            RegisterPacket(CSOffsets.CSChangeHouseNamePacket, 5, typeof(CSChangeHouseNamePacket));
            RegisterPacket(CSOffsets.CSChangeHousePermissionPacket, 5, typeof(CSChangeHousePermissionPacket));
            RegisterPacket(CSOffsets.CSRequestHouseTaxPacket, 5, typeof(CSRequestHouseTaxPacket));
            //RegisterPacket(CSOffsets.CSPerpayHouseTaxPacket, 5, typeof(CSPerpayHouseTaxPacket));
            //RegisterPacket(CSOffsets.CSAllowRecoverPacket, 5, typeof(CSAllowRecoverPacket));
            RegisterPacket(CSOffsets.CSSellHouseCancelPacket, 5, typeof(CSSellHouseCancelPacket));
            RegisterPacket(CSOffsets.CSDecorateHousePacket, 5, typeof(CSDecorateHousePacket));
            RegisterPacket(CSOffsets.CSSellHousePacket, 5, typeof(CSSellHousePacket));
            RegisterPacket(CSOffsets.CSBuyHousePacket, 5, typeof(CSBuyHousePacket));
            //RegisterPacket(CSOffsets.CSRotateHousePacket, 5, typeof(CSRotateHousePacket));
            RegisterPacket(CSOffsets.CSRemoveMatePacket, 5, typeof(CSRemoveMatePacket));
            RegisterPacket(CSOffsets.CSChangeMateTargetPacket, 5, typeof(CSChangeMateTargetPacket));
            RegisterPacket(CSOffsets.CSChangeMateUserStatePacket, 5, typeof(CSChangeMateUserStatePacket));
            RegisterPacket(CSOffsets.CSSpawnSlavePacket, 5, typeof(CSSpawnSlavePacket));
            RegisterPacket(CSOffsets.CSDespawnSlavePacket, 5, typeof(CSDespawnSlavePacket));
            RegisterPacket(CSOffsets.CSDestroySlavePacket, 5, typeof(CSDestroySlavePacket));
            RegisterPacket(CSOffsets.CSBindSlavePacket, 5, typeof(CSBindSlavePacket));
            //RegisterPacket(CSOffsets.CSRemoveAllFieldSlavesPacket, 5, typeof(CSRemoveAllFieldSlavesPacket));
            RegisterPacket(CSOffsets.CSBoardingTransferPacket, 5, typeof(CSBoardingTransferPacket));
            RegisterPacket(CSOffsets.CSTurretStatePacket, 5, typeof(CSTurretStatePacket));
            RegisterPacket(CSOffsets.CSCreateSkillControllerPacket, 5, typeof(CSCreateSkillControllerPacket));
            RegisterPacket(CSOffsets.CSJoinTrialAudiencePacket, 5, typeof(CSJoinTrialAudiencePacket));
            RegisterPacket(CSOffsets.CSLeaveTrialAudiencePacket, 5, typeof(CSLeaveTrialAudiencePacket));
            //RegisterPacket(CSOffsets.CSUnmountMatePacket, 5, typeof(CSUnmountMatePacket));
            //RegisterPacket(CSOffsets.CSUnbondPacket, 5, typeof(CSUnbondPacket));
            RegisterPacket(CSOffsets.CSInstanceLoadedPacket, 5, typeof(CSInstanceLoadedPacket));
            RegisterPacket(CSOffsets.CSApplyToInstantGamePacket, 5, typeof(CSApplyToInstantGamePacket));
            RegisterPacket(CSOffsets.CSCancelInstantGamePacket, 5, typeof(CSCancelInstantGamePacket));
            RegisterPacket(CSOffsets.CSJoinInstantGamePacket, 5, typeof(CSJoinInstantGamePacket));
            RegisterPacket(CSOffsets.CSEnteredInstantGameWorldPacket, 5, typeof(CSEnteredInstantGameWorldPacket));
            RegisterPacket(CSOffsets.CSLeaveInstantGamePacket, 5, typeof(CSLeaveInstantGamePacket));
            //RegisterPacket(CSOffsets.CSPickBuffInstantGamePacket, 5, typeof(CSPickBuffInstantGamePacket));
            //RegisterPacket(CSOffsets.CSBattlefieldPickshipPacket, 5, typeof(CSBattlefieldPickshipPacket));
            //RegisterPacket(CSOffsets.CSRequestPermissionToPlayCinemaForDirectingModePacket, 5, typeof(CSRequestPermissionToPlayCinemaForDirectingModePacket));
            RegisterPacket(CSOffsets.CSStartQuestContextPacket, 5, typeof(CSStartQuestContextPacket));
            RegisterPacket(CSOffsets.CSCompleteQuestContextPacket, 5, typeof(CSCompleteQuestContextPacket));
            RegisterPacket(CSOffsets.CSDropQuestContextPacket, 5, typeof(CSDropQuestContextPacket));
            RegisterPacket(CSOffsets.CSQuestTalkMadePacket, 5, typeof(CSQuestTalkMadePacket));
            //RegisterPacket(CSOffsets.CSQuestStartWithParamPacket, 5, typeof(CSQuestStartWithParamPacket));
            RegisterPacket(CSOffsets.CSTryQuestCompleteAsLetItDonePacket, 5, typeof(CSTryQuestCompleteAsLetItDonePacket));
            RegisterPacket(CSOffsets.CSRestartMainQuestPacket, 5, typeof(CSRestartMainQuestPacket));
            RegisterPacket(CSOffsets.CSLearnSkillPacket, 5, typeof(CSLearnSkillPacket));
            RegisterPacket(CSOffsets.CSLearnBuffPacket, 5, typeof(CSLearnBuffPacket));
            RegisterPacket(CSOffsets.CSResetSkillsPacket, 5, typeof(CSResetSkillsPacket));
            RegisterPacket(CSOffsets.CSSwapAbilityPacket, 5, typeof(CSSwapAbilityPacket));
            //RegisterPacket(CSOffsets.CSSelectHighAbilityPacket, 5, typeof(CSSelectHighAbilityPacket));
            //RegisterPacket(CSOffsets.CSUnknown0x18dPacket, 5, typeof(CSUnknown0x18dPacket));
            RegisterPacket(CSOffsets.CSRemoveBuffPacket, 5, typeof(CSRemoveBuffPacket));
            RegisterPacket(CSOffsets.CSStopCastingPacket, 5, typeof(CSStopCastingPacket));
            RegisterPacket(CSOffsets.CSDeletePortalPacket, 5, typeof(CSDeletePortalPacket));
            //RegisterPacket(CSOffsets.CSIndunDirectTelPacket, 5, typeof(CSIndunDirectTelPacket));
            RegisterPacket(CSOffsets.CSSetForceAttackPacket, 5, typeof(CSSetForceAttackPacket));
            RegisterPacket(CSOffsets.CSStartSkillPacket, 5, typeof(CSStartSkillPacket));
            //RegisterPacket(CSOffsets.CSUnknown0x122Packet, 5, typeof(CSUnknown0x122Packet));
            //RegisterPacket(CSOffsets.CSStopLootingPacket, 5, typeof(CSStopLootingPacket));
            RegisterPacket(CSOffsets.CSCreateDoodadPacket, 5, typeof(CSCreateDoodadPacket));
            RegisterPacket(CSOffsets.CSNaviTeleportPacket, 5, typeof(CSNaviTeleportPacket));
            RegisterPacket(CSOffsets.CSNaviOpenPortalPacket, 5, typeof(CSNaviOpenPortalPacket));
            RegisterPacket(CSOffsets.CSNaviOpenBountyPacket, 5, typeof(CSNaviOpenBountyPacket));
            RegisterPacket(CSOffsets.CSSetLogicDoodadPacket, 5, typeof(CSSetLogicDoodadPacket));
            RegisterPacket(CSOffsets.CSCleanupLogicLinkPacket, 5, typeof(CSCleanupLogicLinkPacket));
            RegisterPacket(CSOffsets.CSSelectInteractionExPacket, 5, typeof(CSSelectInteractionExPacket));
            RegisterPacket(CSOffsets.CSChangeDoodadDataPacket, 5, typeof(CSChangeDoodadDataPacket));
            RegisterPacket(CSOffsets.CSBuyItemsPacket, 5, typeof(CSBuyItemsPacket));
            //RegisterPacket(CSOffsets.CSUnknown0x59Packet, 5, typeof(CSUnknown0x59Packet));
            //RegisterPacket(CSOffsets.CSUnknown0x1a5Packet, 5, typeof(CSUnknown0x1a5Packet));
            //RegisterPacket(CSOffsets.CSUnknown0x30Packet, 5, typeof(CSUnknown0x30Packet));
            //RegisterPacket(CSOffsets.CSUnknown0x5dPacket, 5, typeof(CSUnknown0x5dPacket));
            RegisterPacket(CSOffsets.CSInteractNPCPacket, 5, typeof(CSInteractNPCPacket));
            RegisterPacket(CSOffsets.CSInteractNPCEndPacket, 5, typeof(CSInteractNPCEndPacket));
            //RegisterPacket(CSOffsets.CSBeautyshopBypassPacket, 5, typeof(CSBeautyshopBypassPacket));
            RegisterPacket(CSOffsets.CSSpecialtyRatioPacket, 5, typeof(CSSpecialtyRatioPacket));
            //RegisterPacket(CSOffsets.CSUnknown0x17Packet, 5, typeof(CSUnknown0x17Packet));
            RegisterPacket(CSOffsets.CSJoinUserChatChannelPacket, 5, typeof(CSJoinUserChatChannelPacket));
            RegisterPacket(CSOffsets.CSLeaveChatChannelPacket, 5, typeof(CSLeaveChatChannelPacket));
            RegisterPacket(CSOffsets.CSSendChatMessagePacket, 5, typeof(CSSendChatMessagePacket));
            RegisterPacket(CSOffsets.CSRollDicePacket, 5, typeof(CSRollDicePacket));
            RegisterPacket(CSOffsets.CSSendMailPacket, 5, typeof(CSSendMailPacket));
            RegisterPacket(CSOffsets.CSListMailPacket, 5, typeof(CSListMailPacket));
            RegisterPacket(CSOffsets.CSListMailContinuePacket, 5, typeof(CSListMailContinuePacket));
            RegisterPacket(CSOffsets.CSReadMailPacket, 5, typeof(CSReadMailPacket));
            RegisterPacket(CSOffsets.CSTakeAttachmentMoneyPacket, 5, typeof(CSTakeAttachmentMoneyPacket));
            //RegisterPacket(CSOffsets.CSTakeAttachmentSequentiallyPacket, 5, typeof(CSTakeAttachmentSequentiallyPacket));
            RegisterPacket(CSOffsets.CSPayChargeMoneyPacket, 5, typeof(CSPayChargeMoneyPacket));
            RegisterPacket(CSOffsets.CSDeleteMailPacket, 5, typeof(CSDeleteMailPacket));
            RegisterPacket(CSOffsets.CSReportSpamPacket, 5, typeof(CSReportSpamPacket));
            RegisterPacket(CSOffsets.CSReturnMailPacket, 5, typeof(CSReturnMailPacket));
            //RegisterPacket(CSOffsets.CSTakeAllAttachmentItemPacket, 5, typeof(CSTakeAllAttachmentItemPacket));
            RegisterPacket(CSOffsets.CSTakeAttachmentItemPacket, 5, typeof(CSTakeAttachmentItemPacket));
            RegisterPacket(CSOffsets.CSActiveWeaponChangedPacket, 5, typeof(CSActiveWeaponChangedPacket));
            //RegisterPacket(CSOffsets.CSUnknown0x0d8Packet, 5, typeof(CSUnknown0x0d8Packet));
            //RegisterPacket(CSOffsets.CSRequestExpandAbilitySetSlotPacket, 5, typeof(CSRequestExpandAbilitySetSlotPacket));
            //RegisterPacket(CSOffsets.CSSaveAbilitySetPacket, 5, typeof(CSSaveAbilitySetPacket));
            //RegisterPacket(CSOffsets.CSDeleteAbilitySetPacket, 5, typeof(CSDeleteAbilitySetPacket));
            RegisterPacket(CSOffsets.CSRepairSlaveItemsPacket, 5, typeof(CSRepairSlaveItemsPacket));
            //RegisterPacket(CSOffsets.CSRepairPetItemsPacket, 5, typeof(CSRepairPetItemsPacket));
            //RegisterPacket(CSOffsets.CSFactionIssuanceOfMobilizationOrderPacket, 5, typeof(CSFactionIssuanceOfMobilizationOrderPacket));
            //RegisterPacket(CSOffsets.CSGetExpeditionMyRecruitmentsPacket, 5, typeof(CSGetExpeditionMyRecruitmentsPacket));
            //RegisterPacket(CSOffsets.CSExpeditionRecruitmentAddPacket, 5, typeof(CSExpeditionRecruitmentAddPacket));
            //RegisterPacket(CSOffsets.CSExpeditionRecruitmentDeletePacket, 5, typeof(CSExpeditionRecruitmentDeletePacket));
            //RegisterPacket(CSOffsets.CSGetExpeditionApplicantsPacket, 5, typeof(CSGetExpeditionApplicantsPacket));
            //RegisterPacket(CSOffsets.CSExpeditionApplicantAddPacket, 5, typeof(CSExpeditionApplicantAddPacket));
            //RegisterPacket(CSOffsets.CSExpeditionApplicantDeletePacket, 5, typeof(CSExpeditionApplicantDeletePacket));
            //RegisterPacket(CSOffsets.CSExpeditionApplicantAcceptPacket, 5, typeof(CSExpeditionApplicantAcceptPacket));
            //RegisterPacket(CSOffsets.CSExpeditionApplicantRejectPacket, 5, typeof(CSExpeditionApplicantRejectPacket));
            //RegisterPacket(CSOffsets.CSExpeditionSummonPacket, 5, typeof(CSExpeditionSummonPacket));
            //RegisterPacket(CSOffsets.CSExpeditionSummonReplyPacket, 5, typeof(CSExpeditionSummonReplyPacket));
            //RegisterPacket(CSOffsets.CSInstantTimePacket, 5, typeof(CSInstantTimePacket));
            //RegisterPacket(CSOffsets.CSSetHouseAllowRecoverPacket, 5, typeof(CSSetHouseAllowRecoverPacket));
            //RegisterPacket(CSOffsets.CSRefreshBotCheckInfoPacket, 5, typeof(CSRefreshBotCheckInfoPacket));
            //RegisterPacket(CSOffsets.CSAnswerBotCheckPacket, 5, typeof(CSAnswerBotCheckPacket));
            RegisterPacket(CSOffsets.CSChangeSlaveNamePacket, 5, typeof(CSChangeSlaveNamePacket));
            RegisterPacket(CSOffsets.CSUseTeleportPacket, 5, typeof(CSUseTeleportPacket));
            RegisterPacket(CSOffsets.CSAuctionPostPacket, 5, typeof(CSAuctionPostPacket));
            RegisterPacket(CSOffsets.CSAuctionSearchPacket, 5, typeof(CSAuctionSearchPacket));
            RegisterPacket(CSOffsets.CSAuctionMyBidListPacket, 5, typeof(CSAuctionMyBidListPacket));
            RegisterPacket(CSOffsets.CSAuctionLowestPricePacket, 5, typeof(CSAuctionLowestPricePacket));
            //RegisterPacket(CSOffsets.CSAuctionSearchSoldRecordPacket, 5, typeof(CSAuctionSearchSoldRecordPacket));
            //RegisterPacket(CSOffsets.CSAuctionCancelPacket, 5, typeof(CSAuctionCancelPacket));
            //RegisterPacket(CSOffsets.CSAuctionBidPacket, 5, typeof(CSAuctionBidPacket));
            //RegisterPacket(CSOffsets.CSExecuteCraftPacket, 5, typeof(CSExecuteCraftPacket));
            RegisterPacket(CSOffsets.CSSetLpManageCharacterPacket, 5, typeof(CSSetLpManageCharacterPacket));
            RegisterPacket(CSOffsets.CSSetCraftingPayPacket, 5, typeof(CSSetCraftingPayPacket));
            RegisterPacket(CSOffsets.CSDestroyItemPacket, 5, typeof(CSDestroyItemPacket));
            RegisterPacket(CSOffsets.CSSplitBagItemPacket, 5, typeof(CSSplitBagItemPacket));
            RegisterPacket(CSOffsets.CSSwapItemsPacket, 5, typeof(CSSwapItemsPacket));
            RegisterPacket(CSOffsets.CSSplitCofferItemPacket, 5, typeof(CSSplitCofferItemPacket));
            RegisterPacket(CSOffsets.CSSwapCofferItemsPacket, 5, typeof(CSSwapCofferItemsPacket));
            RegisterPacket(CSOffsets.CSExpandSlotsPacket, 5, typeof(CSExpandSlotsPacket));
            RegisterPacket(CSOffsets.CSDepositMoneyPacket, 5, typeof(CSDepositMoneyPacket));
            RegisterPacket(CSOffsets.CSWithdrawMoneyPacket, 5, typeof(CSWithdrawMoneyPacket));
            RegisterPacket(CSOffsets.CSItemSecurePacket, 5, typeof(CSItemSecurePacket));
            RegisterPacket(CSOffsets.CSItemUnsecurePacket, 5, typeof(CSItemUnsecurePacket));
            RegisterPacket(CSOffsets.CSEquipmentsSecurePacket, 5, typeof(CSEquipmentsSecurePacket));
            RegisterPacket(CSOffsets.CSEquipmentsUnsecurePacket, 5, typeof(CSEquipmentsUnsecurePacket));
            RegisterPacket(CSOffsets.CSRepairSingleEquipmentPacket, 5, typeof(CSRepairSingleEquipmentPacket));
            RegisterPacket(CSOffsets.CSRepairAllEquipmentsPacket, 5, typeof(CSRepairAllEquipmentsPacket));
            //RegisterPacket(CSOffsets.CSChangeAutoUseAAPointPacket, 5, typeof(CSChangeAutoUseAAPointPacket));
            //RegisterPacket(CSOffsets.CSThisTimeUnpackPacket, 5, typeof(CSThisTimeUnpackPacket));
            //RegisterPacket(CSOffsets.CSTakeScheduleItemPacket, 5, typeof(CSTakeScheduleItemPacket));
            RegisterPacket(CSOffsets.CSChangeMateEquipmentPacket, 5, typeof(CSChangeMateEquipmentPacket));
            RegisterPacket(CSOffsets.CSChangeSlaveEquipmentPacket, 5, typeof(CSChangeSlaveEquipmentPacket));
            //RegisterPacket(CSOffsets.CSLoginUccItemsPacket, 5, typeof(CSLoginUccItemsPacket));
            RegisterPacket(CSOffsets.CSLootOpenBagPacket, 5, typeof(CSLootOpenBagPacket));
            RegisterPacket(CSOffsets.CSLootItemPacket, 5, typeof(CSLootItemPacket));
            RegisterPacket(CSOffsets.CSLootCloseBagPacket, 5, typeof(CSLootCloseBagPacket));
            RegisterPacket(CSOffsets.CSLootDicePacket, 5, typeof(CSLootDicePacket));
            RegisterPacket(CSOffsets.CSSellBackpackGoodsPacket, 5, typeof(CSSellBackpackGoodsPacket));
            RegisterPacket(CSOffsets.CSSellItemsPacket, 5, typeof(CSSellItemsPacket));
            RegisterPacket(CSOffsets.CSListSoldItemPacket, 5, typeof(CSListSoldItemPacket));
            //RegisterPacket(CSOffsets.CSSpecialtyCurrentLoadPacket, 5, typeof(CSSpecialtyCurrentLoadPacket));
            RegisterPacket(CSOffsets.CSStartTradePacket, 5, typeof(CSStartTradePacket));
            RegisterPacket(CSOffsets.CSCanStartTradePacket, 5, typeof(CSCanStartTradePacket));
            RegisterPacket(CSOffsets.CSCannotStartTradePacket, 5, typeof(CSCannotStartTradePacket));
            RegisterPacket(CSOffsets.CSCancelTradePacket, 5, typeof(CSCancelTradePacket));
            //RegisterPacket(CSOffsets.CSPutupItemPacket, 5, typeof(CSPutupItemPacket));
            //RegisterPacket(CSOffsets.CSTakedownItemPacket, 5, typeof(CSTakedownItemPacket));
            RegisterPacket(CSOffsets.CSTradeLockPacket, 5, typeof(CSTradeLockPacket));
            RegisterPacket(CSOffsets.CSTradeOkPacket, 5, typeof(CSTradeOkPacket));
            //RegisterPacket(CSOffsets.CSPutupMoneyPacket, 5, typeof(CSPutupMoneyPacket));
            //RegisterPacket(CSOffsets.CSReportSpammer, 5, typeof(CSReportSpammer);

            // это все от версии 1.2
            //RegisterPacket(0x000, 1, typeof(X2EnterWorldPacket));
            //RegisterPacket(0x001, 1, typeof(CSLeaveWorldPacket));
            //RegisterPacket(0x002, 1, typeof(CSCancelLeaveWorldPacket));
            //RegisterPacket(0x004, 1, typeof(CSCreateExpeditionPacket));
            ////RegisterPacket(0x005, 1, typeof(CSChangeExpeditionSponsorPacket)); TODO : this packet seems like it has been removed.
            //RegisterPacket(0x006, 1, typeof(CSChangeExpeditionRolePolicyPacket));
            //RegisterPacket(0x007, 1, typeof(CSChangeExpeditionMemberRolePacket));
            //RegisterPacket(0x008, 1, typeof(CSChangeExpeditionOwnerPacket));
            //RegisterPacket(0x009, 1, typeof(CSRenameExpeditionPacket));
            //RegisterPacket(0x00b, 1, typeof(CSDismissExpeditionPacket));
            //RegisterPacket(0x00c, 1, typeof(CSInviteToExpeditionPacket));
            //RegisterPacket(0x00d, 1, typeof(CSReplyExpeditionInvitationPacket));
            //RegisterPacket(0x00e, 1, typeof(CSLeaveExpeditionPacket));
            //RegisterPacket(0x00f, 1, typeof(CSKickFromExpeditionPacket));
            //// 0x10 unk packet
            //RegisterPacket(0x012, 1, typeof(CSUpdateDominionTaxRatePacket));
            //
            //RegisterPacket(0x015, 1, typeof(CSFactionImmigrationInvitePacket));
            //RegisterPacket(0x016, 1, typeof(CSFactionImmigrationInviteReplyPacket));
            //RegisterPacket(0x017, 1, typeof(CSFactionImmigrateToOriginPacket));
            //RegisterPacket(0x018, 1, typeof(CSFactionKickToOriginPacket));
            //RegisterPacket(0x019, 1, typeof(CSFactionDeclareHostilePacket));
            //RegisterPacket(0x01a, 1, typeof(CSFamilyInviteMemberPacket));
            //RegisterPacket(0x01b, 1, typeof(CSFamilyReplyInvitationPacket));
            //RegisterPacket(0x01c, 1, typeof(CSFamilyLeavePacket));
            //RegisterPacket(0x01d, 1, typeof(CSFamilyKickPacket));
            //RegisterPacket(0x01e, 1, typeof(CSFamilyChangeTitlePacket));
            //RegisterPacket(0x01f, 1, typeof(CSFamilyChangeOwnerPacket));
            //RegisterPacket(0x020, 1, typeof(CSListCharacterPacket));
            //RegisterPacket(0x021, 1, typeof(CSRefreshInCharacterListPacket));
            //RegisterPacket(0x022, 1, typeof(CSCreateCharacterPacket));
            //RegisterPacket(0x023, 1, typeof(CSEditCharacterPacket));
            //RegisterPacket(0x024, 1, typeof(CSDeleteCharacterPacket));
            //RegisterPacket(0x025, 1, typeof(CSSelectCharacterPacket));
            //RegisterPacket(0x026, 1, typeof(CSSpawnCharacterPacket));
            //RegisterPacket(0x027, 1, typeof(CSCancelCharacterDeletePacket));
            //RegisterPacket(0x029, 1, typeof(CSNotifyInGamePacket));
            //RegisterPacket(0x02a, 1, typeof(CSNotifyInGameCompletedPacket));
            //RegisterPacket(0x02b, 1, typeof(CSEditorGameModePacket));
            //RegisterPacket(0x02c, 1, typeof(CSChangeTargetPacket));
            //RegisterPacket(0x02d, 1, typeof(CSRequestCharBriefPacket));
            //RegisterPacket(0x02e, 1, typeof(CSSpawnSlavePacket));
            //RegisterPacket(0x02f, 1, typeof(CSDespawnSlavePacket));
            //RegisterPacket(0x030, 1, typeof(CSDestroySlavePacket));
            //RegisterPacket(0x031, 1, typeof(CSBindSlavePacket));
            //RegisterPacket(0x032, 1, typeof(CSDiscardSlavePacket));
            ////RegisterPacket(0x031, 1, typeof(CSChangeSlaveTargetPacket)); TODO: this packet is not in the offsets
            //RegisterPacket(0x034, 1, typeof(CSChangeSlaveNamePacket));
            //RegisterPacket(0x035, 1, typeof(CSRepairSlaveItemsPacket));
            //RegisterPacket(0x036, 1, typeof(CSTurretStatePacket));
            //RegisterPacket(0x037, 1, typeof(CSChangeSlaveEquipmentPacket));
            //RegisterPacket(0x038, 1, typeof(CSDestroyItemPacket));
            //RegisterPacket(0x039, 1, typeof(CSSplitBagItemPacket));
            //RegisterPacket(0x03a, 1, typeof(CSSwapItemsPacket));
            //RegisterPacket(0x03c, 1, typeof(CSRepairSingleEquipmentPacket));
            //RegisterPacket(0x03d, 1, typeof(CSRepairAllEquipmentsPacket));
            //RegisterPacket(0x03f, 1, typeof(CSSplitCofferItemPacket));
            //RegisterPacket(0x040, 1, typeof(CSSwapCofferItemsPacket));
            //RegisterPacket(0x041, 1, typeof(CSExpandSlotsPacket));
            //RegisterPacket(0x042, 1, typeof(CSSellBackpackGoodsPacket));
            //RegisterPacket(0x043, 1, typeof(CSSpecialtyRatioPacket));
            //RegisterPacket(0x044, 1, typeof(CSListSpecialtyGoodsPacket));
            ////RegisterPacket(0x043, 1, typeof(CSBuySpecialtyItemPacket)); TODO: this packet is not in the offsets
            ////RegisterPacket(0x044, 1, typeof(CSSpecialtyRecordLoadPacket)); TODO: this packet is not in the offsets
            //RegisterPacket(0x047, 1, typeof(CSDepositMoneyPacket));
            //RegisterPacket(0x048, 1, typeof(CSWithdrawMoneyPacket));
            //RegisterPacket(0x049, 1, typeof(CSConvertItemLookPacket));
            //RegisterPacket(0x04a, 1, typeof(CSItemSecurePacket));
            //RegisterPacket(0x04b, 1, typeof(CSItemUnsecurePacket));
            //RegisterPacket(0x04c, 1, typeof(CSEquipmentsSecurePacket));
            //RegisterPacket(0x04d, 1, typeof(CSEquipmentsUnsecurePacket));
            //RegisterPacket(0x04e, 1, typeof(CSResurrectCharacterPacket));
            //RegisterPacket(0x04f, 1, typeof(CSSetForceAttackPacket));
            //RegisterPacket(0x050, 1, typeof(CSChallengeDuelPacket));
            //RegisterPacket(0x051, 1, typeof(CSStartDuelPacket));
            //RegisterPacket(0x052, 1, typeof(CSStartSkillPacket));
            //RegisterPacket(0x054, 1, typeof(CSStopCastingPacket));
            //RegisterPacket(0x055, 1, typeof(CSRemoveBuffPacket));
            //RegisterPacket(0x056, 1, typeof(CSConstructHouseTaxPacket));
            //RegisterPacket(0x057, 1, typeof(CSCreateHousePacket));
            //RegisterPacket(0x058, 1, typeof(CSDecorateHousePacket));
            //RegisterPacket(0x059, 1, typeof(CSChangeHouseNamePacket));
            //RegisterPacket(0x05a, 1, typeof(CSChangeHousePermissionPacket));
            ////RegisterPacket(0x05b, 1, typeof(CSChangeHousePayPacket)); TODO: this packet is not in the offsets
            //RegisterPacket(0x05c, 1, typeof(CSRequestHouseTaxPacket));
            //// 0x5c unk packet
            //RegisterPacket(0x05d, 1, typeof(CSAllowHousingRecoverPacket));
            //RegisterPacket(0x05e, 1, typeof(CSSellHousePacket));
            //RegisterPacket(0x05f, 1, typeof(CSSellHouseCancelPacket));
            //RegisterPacket(0x060, 1, typeof(CSBuyHousePacket));
            //RegisterPacket(0x061, 1, typeof(CSJoinUserChatChannelPacket));
            //RegisterPacket(0x062, 1, typeof(CSLeaveChatChannelPacket));
            //RegisterPacket(0x063, 1, typeof(CSSendChatMessagePacket));
            //RegisterPacket(0x064, 1, typeof(CSConsoleCmdUsedPacket));
            //RegisterPacket(0x065, 1, typeof(CSInteractNPCPacket));
            //RegisterPacket(0x066, 1, typeof(CSInteractNPCEndPacket));
            //RegisterPacket(0x067, 1, typeof(CSBoardingTransferPacket));
            //RegisterPacket(0x068, 1, typeof(CSStartInteractionPacket));
            //RegisterPacket(0x06b, 1, typeof(CSSelectInteractionExPacket));
            //RegisterPacket(0x06c, 1, typeof(CSCofferInteractionPacket));
            //RegisterPacket(0x06e, 1, typeof(CSCriminalLockedPacket));
            //RegisterPacket(0x06f, 1, typeof(CSReplyImprisonOrTrialPacket));
            //RegisterPacket(0x070, 1, typeof(CSSkipFinalStatementPacket));
            //RegisterPacket(0x071, 1, typeof(CSReplyInviteJuryPacket));
            //RegisterPacket(0x072, 1, typeof(CSJurySummonedPacket));
            //RegisterPacket(0x073, 1, typeof(CSJuryEndTestimonyPacket));
            //RegisterPacket(0x074, 1, typeof(CSCancelTrialPacket));
            //RegisterPacket(0x075, 1, typeof(CSJuryVerdictPacket));
            //RegisterPacket(0x076, 1, typeof(CSReportCrimePacket));
            //RegisterPacket(0x077, 1, typeof(CSJoinTrialAudiencePacket));
            //RegisterPacket(0x078, 1, typeof(CSLeaveTrialAudiencePacket));
            //RegisterPacket(0x079, 1, typeof(CSRequestJuryWaitingNumberPacket));
            //RegisterPacket(0x07a, 1, typeof(CSInviteToTeamPacket));
            //RegisterPacket(0x07b, 1, typeof(CSInviteAreaToTeamPacket));
            //RegisterPacket(0x07c, 1, typeof(CSReplyToJoinTeamPacket));
            //RegisterPacket(0x07d, 1, typeof(CSLeaveTeamPacket));
            //RegisterPacket(0x07e, 1, typeof(CSKickTeamMemberPacket));
            //RegisterPacket(0x07f, 1, typeof(CSMakeTeamOwnerPacket));
            ////RegisterPacket(0x07e, 1, typeof(CSSetTeamOfficerPacket)); TODO: this packet is not in the offsets 
            //RegisterPacket(0x080, 1, typeof(CSConvertToRaidTeamPacket));
            //RegisterPacket(0x081, 1, typeof(CSMoveTeamMemberPacket));
            //RegisterPacket(0x083, 1, typeof(CSChangeLootingRulePacket));
            //RegisterPacket(0x084, 1, typeof(CSDismissTeamPacket));
            //RegisterPacket(0x085, 1, typeof(CSSetTeamMemberRolePacket));
            //RegisterPacket(0x086, 1, typeof(CSSetOverHeadMarkerPacket));
            //RegisterPacket(0x087, 1, typeof(CSSetPingPosPacket));
            //RegisterPacket(0x088, 1, typeof(CSAskRiskyTeamActionPacket));
            //RegisterPacket(0x089, 1, typeof(CSMoveUnitPacket));
            //RegisterPacket(0x08a, 1, typeof(CSSkillControllerStatePacket));
            //RegisterPacket(0x08b, 1, typeof(CSCreateSkillControllerPacket));
            //
            ////RegisterPacket(0x08d, 1, typeof(CSChangeItemLookPacket)); TODO: this packet is not in the offsets 
            //RegisterPacket(0x08e, 1, typeof(CSLootOpenBagPacket));
            //RegisterPacket(0x08f, 1, typeof(CSLootItemPacket));
            //
            //RegisterPacket(0x090, 1, typeof(CSLootCloseBagPacket));
            //RegisterPacket(0x091, 1, typeof(CSLootDicePacket));
            //RegisterPacket(0x092, 1, typeof(CSLearnSkillPacket));
            //RegisterPacket(0x093, 1, typeof(CSLearnBuffPacket));
            //RegisterPacket(0x094, 1, typeof(CSResetSkillsPacket));
            //RegisterPacket(0x096, 1, typeof(CSSwapAbilityPacket));
            //RegisterPacket(0x098, 1, typeof(CSSendMailPacket));
            //RegisterPacket(0x09a, 1, typeof(CSListMailPacket));
            //RegisterPacket(0x09b, 1, typeof(CSListMailContinuePacket));
            //RegisterPacket(0x09c, 1, typeof(CSReadMailPacket));
            //RegisterPacket(0x09d, 1, typeof(CSTakeAttachmentItemPacket));
            //RegisterPacket(0x09e, 1, typeof(CSTakeAttachmentMoneyPacket));
            //// 0x9f unk packet
            //RegisterPacket(0x0a0, 1, typeof(CSPayChargeMoneyPacket));
            //RegisterPacket(0x0a1, 1, typeof(CSDeleteMailPacket));
            //RegisterPacket(0x0a3, 1, typeof(CSReportSpamPacket));
            ////RegisterPacket(0x0a1, 1, typeof(CSReturnMailPacket)); TODO: this packet is not in the offsets 
            //RegisterPacket(0x0a4, 1, typeof(CSRemoveMatePacket));
            //RegisterPacket(0x0a5, 1, typeof(CSChangeMateTargetPacket));
            //RegisterPacket(0x0a6, 1, typeof(CSChangeMateNamePacket));
            //RegisterPacket(0x0a7, 1, typeof(CSMountMatePacket));
            //RegisterPacket(0x0a8, 1, typeof(CSUnMountMatePacket));
            //RegisterPacket(0x0a9, 1, typeof(CSChangeMateEquipmentPacket));
            //RegisterPacket(0x0aa, 1, typeof(CSChangeMateUserStatePacket));
            //// 0xab unk packet
            //// 0xac unk packet
            //RegisterPacket(0x0ad, 1, typeof(CSExpressEmotionPacket));
            //RegisterPacket(0x0ae, 1, typeof(CSBuyItemsPacket));
            //RegisterPacket(0x0af, 1, typeof(CSBuyCoinItemPacket));
            //RegisterPacket(0x0b0, 1, typeof(CSSellItemsPacket));
            //RegisterPacket(0x0b1, 1, typeof(CSListSoldItemPacket));
            //RegisterPacket(0x0b2, 1, typeof(CSBuyPriestBuffPacket));
            //RegisterPacket(0x0b3, 1, typeof(CSUseTeleportPacket));
            //RegisterPacket(0x0b4, 1, typeof(CSTeleportEndedPacket));
            //RegisterPacket(0x0b5, 1, typeof(CSRepairPetItemsPacket));
            //RegisterPacket(0x0b6, 1, typeof(CSUpdateActionSlotPacket));
            //RegisterPacket(0x0b7, 1, typeof(CSAuctionPostPacket));
            //RegisterPacket(0x0b8, 1, typeof(CSAuctionSearchPacket));
            //RegisterPacket(0x0b9, 1, typeof(CSBidAuctionPacket));
            //RegisterPacket(0x0ba, 1, typeof(CSCancelAuctionPacket));
            //RegisterPacket(0x0bb, 1, typeof(CSAuctionMyBidListPacket));
            //RegisterPacket(0x0bc, 1, typeof(CSAuctionLowestPricePacket));
            //RegisterPacket(0x0bd, 1, typeof(CSRollDicePacket));
            ////0xbf CSRequestNpcSpawnerList
            //
            ////0xc8 CSRemoveAllFieldSlaves
            ////0xc9 CSAddFieldSlave
            //RegisterPacket(0x0cb, 1, typeof(CSHangPacket));
            //RegisterPacket(0x0cc, 1, typeof(CSUnhangPacket));
            //
            //RegisterPacket(0x0ce, 1, typeof(CSCompletedCinemaPacket));
            //RegisterPacket(0x0cf, 1, typeof(CSStartedCinemaPacket));
            ////0xd0 CSRequestPermissionToPlayCinemaForDirectingMode
            ////0xd1 CSEditorRemoveGimmickPacket
            ////0xd2 CSEditorAddGimmickPacket
            ////0xd3 CSInteractGimmickPacket
            ////0xd4 CSWorldRayCastingPacket
            //RegisterPacket(0x0d5, 1, typeof(CSStartQuestContextPacket));
            //RegisterPacket(0x0d6, 1, typeof(CSCompleteQuestContextPacket));
            //RegisterPacket(0x0d7, 1, typeof(CSDropQuestContextPacket));
            ////RegisterPacket(0x0d4, 1, typeof(CSResetQuestContextPacket)); TODO: this packet is not in the offsets 
            ////RegisterPacket(0x0d5, 1, typeof(CSAcceptCheatQuestContextPacket)); TODO: this packet is not in the offsets 
            //RegisterPacket(0x0da, 1, typeof(CSQuestTalkMadePacket));
            //RegisterPacket(0x0db, 1, typeof(CSQuestStartWithPacket));
            //RegisterPacket(0x0dd, 1, typeof(CSTryQuestCompleteAsLetItDonePacket));
            //RegisterPacket(0x0de, 1, typeof(CSUsePortalPacket));
            //RegisterPacket(0x0df, 1, typeof(CSDeletePortalPacket));
            //RegisterPacket(0x0e0, 1, typeof(CSInstanceLoadedPacket));
            //RegisterPacket(0x0e1, 1, typeof(CSApplyToInstantGamePacket));
            //RegisterPacket(0x0e2, 1, typeof(CSCancelInstantGamePacket));
            //RegisterPacket(0x0e3, 1, typeof(CSJoinInstantGamePacket));
            //RegisterPacket(0x0e4, 1, typeof(CSEnteredInstantGameWorldPacket));
            //RegisterPacket(0x0e5, 1, typeof(CSLeaveInstantGamePacket));
            //RegisterPacket(0x0e6, 1, typeof(CSCreateDoodadPacket));
            ////RegisterPacket(0x0e3, 1, typeof(CSSaveDoodadUccStringPacket)); TODO: this packet is not in the offsets 
            //RegisterPacket(0x0e7, 1, typeof(CSNaviTeleportPacket));
            //RegisterPacket(0x0e8, 1, typeof(CSNaviOpenPortalPacket));
            //RegisterPacket(0x0e9, 1, typeof(CSChangeDoodadPhasePacket));
            //RegisterPacket(0x0ea, 1, typeof(CSNaviOpenBountyPacket));
            //RegisterPacket(0x0eb, 1, typeof(CSChangeDoodadDataPacket));
            //RegisterPacket(0x0ec, 1, typeof(CSStartTradePacket));
            //RegisterPacket(0x0ed, 1, typeof(CSCanStartTradePacket));
            //RegisterPacket(0x0ee, 1, typeof(CSCannotStartTradePacket));
            //RegisterPacket(0x0ef, 1, typeof(CSCancelTradePacket));
            //RegisterPacket(0x0f0, 1, typeof(CSPutupTradeItemPacket));
            //RegisterPacket(0x0f1, 1, typeof(CSPutupTradeMoneyPacket));
            //RegisterPacket(0x0f2, 1, typeof(CSTakedownTradeItemPacket));
            //RegisterPacket(0x0f3, 1, typeof(CSTradeLockPacket));
            //RegisterPacket(0x0f4, 1, typeof(CSTradeOkPacket));
            //RegisterPacket(0x0f5, 1, typeof(CSSaveTutorialPacket));
            //RegisterPacket(0x0f6, 1, typeof(CSSetLogicDoodadPacket));
            //RegisterPacket(0x0f7, 1, typeof(CSCleanupLogicLinkPacket));
            //RegisterPacket(0x0f8, 1, typeof(CSExecuteCraft));
            //RegisterPacket(0x0f9, 1, typeof(CSChangeAppellationPacket));
            //RegisterPacket(0x0fc, 1, typeof(CSCreateShipyardPacket));
            //RegisterPacket(0x0fd, 1, typeof(CSRestartMainQuestPacket));
            //RegisterPacket(0x0fe, 1, typeof(CSSetLpManageCharacterPacket));
            //RegisterPacket(0x0ff, 1, typeof(CSUpgradeExpertLimitPacket));
            //RegisterPacket(0x100, 1, typeof(CSDowngradeExpertLimitPacket));
            //RegisterPacket(0x101, 1, typeof(CSExpandExpertPacket));
            ////RegisterPacket(0x100, 1, typeof(CSSearchListPacket)); TODO: this packet is not in the offsets 
            //RegisterPacket(0x104, 1, typeof(CSAddFriendPacket));
            //RegisterPacket(0x105, 1, typeof(CSDeleteFriendPacket));
            //RegisterPacket(0x106, 1, typeof(CSCharDetailPacket));
            //RegisterPacket(0x107, 1, typeof(CSAddBlockedUserPacket));
            //RegisterPacket(0x108, 1, typeof(CSDeleteBlockedUserPacket));
            //RegisterPacket(0x112, 1, typeof(CSNotifySubZonePacket));
            //RegisterPacket(0x115, 1, typeof(CSResturnAddrsPacket));
            //RegisterPacket(0x117, 1, typeof(CSRequestUIDataPacket));
            //RegisterPacket(0x118, 1, typeof(CSSaveUIDataPacket));
            //RegisterPacket(0x119, 1, typeof(CSBroadcastVisualOptionPacket));
            //RegisterPacket(0x11a, 1, typeof(CSRestrictCheckPacket));
            //RegisterPacket(0x11b, 1, typeof(CSICSMenuListPacket));
            //RegisterPacket(0x11c, 1, typeof(CSICSGoodsListPacket));
            //RegisterPacket(0x11d, 1, typeof(CSICSBuyGoodPacket));
            //RegisterPacket(0x11e, 1, typeof(CSICSMoneyRequestPacket));
            //// 0x12e CSEnterBeautySalonPacket
            //RegisterPacket(0x12F, 1, typeof(CSRankCharacterPacket));
            //RegisterPacket(0x125, 1, typeof(CSRequestSecondPasswordKeyTablesPacket));
            //// 0x130 CSRankSnapshotPacket
            //// 0x131 unk packet
            //RegisterPacket(0x132, 1, typeof(CSIdleStatusPacket));
            //// 0x133 CSChangeAutoUseAAPointPacket
            //RegisterPacket(0x134, 1, typeof(CSThisTimeUnpackItemPacket));
            //RegisterPacket(0x135, 1, typeof(CSPremiumServiceBuyPacket));
            //RegisterPacket(0x136, 1, typeof(CSPremiumServiceListPacket));
            //// 0x137 CSICSBuyAAPointPacket
            //// 0x138 CSRequestTencentFatigueInfoPacket
            //// 0x139 CSTakeAllAttachmentItemPacket
            //// 0x13a unk packet
            //// 0x13b unk packet
            //RegisterPacket(0x13c, 1, typeof(CSPremiumServieceMsgPacket));
            //// 0x13d unk packet
            //// 0x13e unk packet
            //// 0x13f unk packet
            //RegisterPacket(0x140, 1, typeof(CSSetupSecondPassword));
            //// 0x141 unk packet
            //// 0x142 unk packet

            // Proxy
            RegisterPacket(0x000, 2, typeof(ChangeStatePacket));
            RegisterPacket(0x001, 2, typeof(FinishStatePacket));
            RegisterPacket(0x002, 2, typeof(FlushMsgsPacket));
            RegisterPacket(0x004, 2, typeof(UpdatePhysicsTimePacket));
            RegisterPacket(0x005, 2, typeof(BeginUpdateObjPacket));
            RegisterPacket(0x006, 2, typeof(EndUpdateObjPacket));
            RegisterPacket(0x007, 2, typeof(BeginBindObjPacket));
            RegisterPacket(0x008, 2, typeof(EndBindObjPacket));
            RegisterPacket(0x009, 2, typeof(UnbindPredictedObjPacket));
            RegisterPacket(0x00A, 2, typeof(RemoveStaticObjPacket));
            RegisterPacket(0x00B, 2, typeof(VoiceDataPacket));
            RegisterPacket(0x00C, 2, typeof(UpdateAspectPacket));
            RegisterPacket(0x00D, 2, typeof(SetAspectProfilePacket));
            RegisterPacket(0x00E, 2, typeof(PartialAspectPacket));
            RegisterPacket(0x00F, 2, typeof(SetGameTypePacket));
            RegisterPacket(0x010, 2, typeof(ChangeCVarPacket));
            RegisterPacket(0x011, 2, typeof(EntityClassRegistrationPacket));
            RegisterPacket(0x012, 2, typeof(PingPacket));
            RegisterPacket(0x013, 2, typeof(PongPacket));
            RegisterPacket(0x014, 2, typeof(PacketSeqChange));
            RegisterPacket(0x015, 2, typeof(FastPingPacket));
            RegisterPacket(0x016, 2, typeof(FastPongPacket));
        }

        public void Start()
        {
            var config = AppConfiguration.Instance.Network;
            _server = new Server(new IPEndPoint(config.Host.Equals("*") ? IPAddress.Any : IPAddress.Parse(config.Host), config.Port), 10);
            _server.SetHandler(_handler);
            _server.Start();

            _log.Info("Network started");
        }

        public void Stop()
        {
            if (_server.IsStarted)
                _server.Stop();

            _log.Info("Network stoped");
        }

        private void RegisterPacket(uint type, byte level, Type classType)
        {
            _handler.RegisterPacket(type, level, classType);
        }
    }
}
