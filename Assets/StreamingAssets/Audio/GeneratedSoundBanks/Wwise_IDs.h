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
        static const AkUniqueID CLOCK_TICK = 2719257531U;
        static const AkUniqueID DOOR_OPEN = 535830432U;
        static const AkUniqueID FOOTSTEP_SWITCH = 442453602U;
        static const AkUniqueID KEY_PICKUP = 761761105U;
        static const AkUniqueID KEY_UNLOCK = 2054027409U;
        static const AkUniqueID MENU_GAMESTART = 3860585191U;
        static const AkUniqueID MENU_MOUSEOVER = 547805114U;
        static const AkUniqueID MENU_SELECT = 4203375351U;
        static const AkUniqueID MUSIC_SWITCH = 2724869341U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace MUSIC_SWITCH
        {
            static const AkUniqueID GROUP = 2724869341U;

            namespace STATE
            {
                static const AkUniqueID CANDLE_RUNNINGOUT = 2305435894U;
                static const AkUniqueID DEATH = 779278001U;
                static const AkUniqueID GAME_START = 733168346U;
                static const AkUniqueID MENU = 2607556080U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace MUSIC_SWITCH

    } // namespace STATES

    namespace SWITCHES
    {
        namespace FOOTSTEP_SWITCH
        {
            static const AkUniqueID GROUP = 442453602U;

            namespace SWITCH
            {
                static const AkUniqueID CARPET = 2412606308U;
                static const AkUniqueID CONCRETE = 841620460U;
                static const AkUniqueID SQUISH = 1531833962U;
                static const AkUniqueID WOOD = 2058049674U;
            } // namespace SWITCH
        } // namespace FOOTSTEP_SWITCH

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID PLAYBACK_RATE = 1524500807U;
        static const AkUniqueID RPM = 796049864U;
        static const AkUniqueID SS_AIR_FEAR = 1351367891U;
        static const AkUniqueID SS_AIR_FREEFALL = 3002758120U;
        static const AkUniqueID SS_AIR_FURY = 1029930033U;
        static const AkUniqueID SS_AIR_MONTH = 2648548617U;
        static const AkUniqueID SS_AIR_PRESENCE = 3847924954U;
        static const AkUniqueID SS_AIR_RPM = 822163944U;
        static const AkUniqueID SS_AIR_SIZE = 3074696722U;
        static const AkUniqueID SS_AIR_STORM = 3715662592U;
        static const AkUniqueID SS_AIR_TIMEOFDAY = 3203397129U;
        static const AkUniqueID SS_AIR_TURBULENCE = 4160247818U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID CLOCK_TICK = 2719257531U;
        static const AkUniqueID DOOR_OPEN = 535830432U;
        static const AkUniqueID FOOTSTEP_SWITCH = 442453602U;
        static const AkUniqueID KEY_PICKUP = 761761105U;
        static const AkUniqueID KEY_UNLOCK = 2054027409U;
        static const AkUniqueID MENU_GAMESTART = 3860585191U;
        static const AkUniqueID MENU_MOUSEOVER = 547805114U;
        static const AkUniqueID MENU_SELECT = 4203375351U;
        static const AkUniqueID MUSIC_SWITCH = 2724869341U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MOTION_FACTORY_BUS = 985987111U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID DEFAULT_MOTION_DEVICE = 4230635974U;
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
