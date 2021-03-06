/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID ARRESTED_EVENT = 378908400U;
        static const AkUniqueID CRASH_OBSTACLE_EVENT = 2413921907U;
        static const AkUniqueID GAME_MUSIC_EVENT = 3625263358U;
        static const AkUniqueID PICK_COLLECTIBLE_EVENT = 4173814816U;
        static const AkUniqueID POLICE_ALARM_EVENT = 68097940U;
        static const AkUniqueID POLICE_MOTO_EVENT = 2476389456U;
        static const AkUniqueID ROLLER_DESTROYED_EVENT = 1962511028U;
        static const AkUniqueID ROLLER_SOUND_EVENT = 3738053536U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace EXPLO_OR_CHASE_GROUP
        {
            static const AkUniqueID GROUP = 2123311288U;

            namespace STATE
            {
                static const AkUniqueID CHASE = 417490929U;
                static const AkUniqueID EXPLORATION = 2582085496U;
                static const AkUniqueID GAME_OVER = 1432716332U;
            } // namespace STATE
        } // namespace EXPLO_OR_CHASE_GROUP

        namespace GROUND_OR_AIR_GROUP
        {
            static const AkUniqueID GROUP = 582155773U;

            namespace STATE
            {
                static const AkUniqueID AIR = 1050421051U;
                static const AkUniqueID GROUND = 2528658256U;
            } // namespace STATE
        } // namespace GROUND_OR_AIR_GROUP

        namespace MOTO_OR_NOT_GROUP
        {
            static const AkUniqueID GROUP = 1667447500U;

            namespace STATE
            {
                static const AkUniqueID MOTO = 3044759698U;
                static const AkUniqueID NO_MOTO = 4199420240U;
            } // namespace STATE
        } // namespace MOTO_OR_NOT_GROUP

    } // namespace STATES

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
