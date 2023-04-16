// Autogenerated with StateSmith.
// Algorithm: Balanced1. See https://github.com/StateSmith/StateSmith/wiki/Algorithms

#include "Ex2.h"
#include <stdbool.h> // required for `consume_event` flag
#include <string.h> // for memset

// This function is used when StateSmith doesn't know what the active leaf state is at
// compile time due to sub states or when multiple states need to be exited.
static void exit_up_to_state_handler(Ex2* sm, Ex2_Func desired_state_exit_handler);

static void ROOT_enter(Ex2* sm);

static void ROOT_exit(Ex2* sm);

static void STATE_1_enter(Ex2* sm);

static void STATE_1_exit(Ex2* sm);

static void STATE_1_do(Ex2* sm);

static void STATE_2_enter(Ex2* sm);

static void STATE_2_exit(Ex2* sm);

static void STATE_2_ev2(Ex2* sm);

static void STATE_2_myev1(Ex2* sm);


// State machine constructor. Must be called before start or dispatch event functions. Not thread safe.
void Ex2_ctor(Ex2* sm)
{
    memset(sm, 0, sizeof(*sm));
}

// Starts the state machine. Must be called before dispatching events. Not thread safe.
void Ex2_start(Ex2* sm)
{
    ROOT_enter(sm);
    // ROOT behavior
    // uml: TransitionTo(ROOT.InitialState)
    {
        // Step 1: Exit states until we reach `ROOT` state (Least Common Ancestor for transition). Already at LCA, no exiting required.
        
        // Step 2: Transition action: ``.
        
        // Step 3: Enter/move towards transition target `ROOT.InitialState`.
        // ROOT.InitialState is a pseudo state and cannot have an `enter` trigger.
        
        // ROOT.InitialState behavior
        // uml: TransitionTo(STATE_1)
        {
            // Step 1: Exit states until we reach `ROOT` state (Least Common Ancestor for transition). Already at LCA, no exiting required.
            
            // Step 2: Transition action: ``.
            
            // Step 3: Enter/move towards transition target `STATE_1`.
            STATE_1_enter(sm);
            
            // Step 4: complete transition. Ends event dispatch. No other behaviors are checked.
            sm->state_id = Ex2_StateId_STATE_1;
            // No ancestor handles event. Can skip nulling `ancestor_event_handler`.
            return;
        } // end of behavior for ROOT.InitialState
    } // end of behavior for ROOT
}

// Dispatches an event to the state machine. Not thread safe.
void Ex2_dispatch_event(Ex2* sm, Ex2_EventId event_id)
{
    Ex2_Func behavior_func = sm->current_event_handlers[event_id];
    
    while (behavior_func != NULL)
    {
        sm->ancestor_event_handler = NULL;
        behavior_func(sm);
        behavior_func = sm->ancestor_event_handler;
    }
}

// This function is used when StateSmith doesn't know what the active leaf state is at
// compile time due to sub states or when multiple states need to be exited.
static void exit_up_to_state_handler(Ex2* sm, Ex2_Func desired_state_exit_handler)
{
    while (sm->current_state_exit_handler != desired_state_exit_handler)
    {
        sm->current_state_exit_handler(sm);
    }
}


////////////////////////////////////////////////////////////////////////////////
// event handlers for state ROOT
////////////////////////////////////////////////////////////////////////////////

static void ROOT_enter(Ex2* sm)
{
    // setup trigger/event handlers
    sm->current_state_exit_handler = ROOT_exit;
}

static void ROOT_exit(Ex2* sm)
{
    // State machine root is a special case. It cannot be exited. Mark as unused.
    (void)sm;
}


////////////////////////////////////////////////////////////////////////////////
// event handlers for state STATE_1
////////////////////////////////////////////////////////////////////////////////

static void STATE_1_enter(Ex2* sm)
{
    // setup trigger/event handlers
    sm->current_state_exit_handler = STATE_1_exit;
    sm->current_event_handlers[Ex2_EventId_DO] = STATE_1_do;
}

static void STATE_1_exit(Ex2* sm)
{
    // adjust function pointers for this state's exit
    sm->current_state_exit_handler = ROOT_exit;
    sm->current_event_handlers[Ex2_EventId_DO] = NULL;  // no ancestor listens to this event
}

static void STATE_1_do(Ex2* sm)
{
    // No ancestor state handles `do` event.
    
    // STATE_1 behavior
    // uml: do TransitionTo(STATE_2)
    {
        // Step 1: Exit states until we reach `ROOT` state (Least Common Ancestor for transition).
        STATE_1_exit(sm);
        
        // Step 2: Transition action: ``.
        
        // Step 3: Enter/move towards transition target `STATE_2`.
        STATE_2_enter(sm);
        
        // Step 4: complete transition. Ends event dispatch. No other behaviors are checked.
        sm->state_id = Ex2_StateId_STATE_2;
        // No ancestor handles event. Can skip nulling `ancestor_event_handler`.
        return;
    } // end of behavior for STATE_1
}


////////////////////////////////////////////////////////////////////////////////
// event handlers for state STATE_2
////////////////////////////////////////////////////////////////////////////////

static void STATE_2_enter(Ex2* sm)
{
    // setup trigger/event handlers
    sm->current_state_exit_handler = STATE_2_exit;
    sm->current_event_handlers[Ex2_EventId_EV2] = STATE_2_ev2;
    sm->current_event_handlers[Ex2_EventId_MYEV1] = STATE_2_myev1;
}

static void STATE_2_exit(Ex2* sm)
{
    // adjust function pointers for this state's exit
    sm->current_state_exit_handler = ROOT_exit;
    sm->current_event_handlers[Ex2_EventId_EV2] = NULL;  // no ancestor listens to this event
    sm->current_event_handlers[Ex2_EventId_MYEV1] = NULL;  // no ancestor listens to this event
}

static void STATE_2_ev2(Ex2* sm)
{
    // No ancestor state handles `ev2` event.
    
    // STATE_2 behavior
    // uml: EV2 / { stuff(); }
    {
        // Step 1: execute action `stuff();`
        stuff();
        
        // Step 2: determine if ancestor gets to handle event next.
        // No ancestor handles event. Can skip nulling `ancestor_event_handler`.
    } // end of behavior for STATE_2
}

static void STATE_2_myev1(Ex2* sm)
{
    // No ancestor state handles `myev1` event.
    
    // STATE_2 behavior
    // uml: myEv1 / { do_stuff(); }
    {
        // Step 1: execute action `do_stuff();`
        do_stuff();
        
        // Step 2: determine if ancestor gets to handle event next.
        // No ancestor handles event. Can skip nulling `ancestor_event_handler`.
    } // end of behavior for STATE_2
}

// Thread safe.
char const * Ex2_state_id_to_string(Ex2_StateId id)
{
    switch (id)
    {
        case Ex2_StateId_ROOT: return "ROOT";
        case Ex2_StateId_STATE_1: return "STATE_1";
        case Ex2_StateId_STATE_2: return "STATE_2";
        default: return "?";
    }
}

// Thread safe.
char const * Ex2_event_id_to_string(Ex2_EventId id)
{
    switch (id)
    {
        case Ex2_EventId_DO: return "DO";
        case Ex2_EventId_EV2: return "EV2";
        case Ex2_EventId_MYEV1: return "MYEV1";
        default: return "?";
    }
}
// Converts an event id to a string. Thread safe.
const char* Ex2_event_id_to_string(const enum EventId id)
{
    switch (id)
    {
        case DO: return "do";
        case EV2: return "ev2";
        case MYEV1: return "myev1";
    }
    return "?";
}
