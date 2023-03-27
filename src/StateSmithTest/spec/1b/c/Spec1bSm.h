// Autogenerated with StateSmith 0.8.11-alpha.
// Algorithm: Balanced1. See https://github.com/StateSmith/StateSmith/wiki/Algorithms

#pragma once
#include <stdint.h>

// any text you put in IRenderConfigC.HFileIncludes (like this comment) will be written to the generated .h file
typedef enum Spec1bSm_EventId
{
    Spec1bSm_EventId_T1 = 0,
} Spec1bSm_EventId;

enum
{
    Spec1bSm_EventIdCount = 1
};

typedef enum Spec1bSm_StateId
{
    Spec1bSm_StateId_ROOT = 0,
    Spec1bSm_StateId_S = 1,
    Spec1bSm_StateId_S1 = 2,
    Spec1bSm_StateId_S1_1 = 3,
    Spec1bSm_StateId_S2 = 4,
    Spec1bSm_StateId_S2_1 = 5,
} Spec1bSm_StateId;

enum
{
    Spec1bSm_StateIdCount = 6
};


// Generated state machine
// forward declaration
typedef struct Spec1bSm Spec1bSm;

// State machine variables. Can be used for inputs, outputs, user variables...
typedef struct Spec1bSm_Vars
{
    uint8_t count;
} Spec1bSm_Vars;


// event handler type
typedef void (*Spec1bSm_Func)(Spec1bSm* sm);

// State machine constructor. Must be called before start or dispatch event functions. Not thread safe.
void Spec1bSm_ctor(Spec1bSm* sm);

// Starts the state machine. Must be called before dispatching events. Not thread safe.
void Spec1bSm_start(Spec1bSm* sm);

// Dispatches an event to the state machine. Not thread safe.
void Spec1bSm_dispatch_event(Spec1bSm* sm, Spec1bSm_EventId event_id);

// Thread safe.
char const * Spec1bSm_state_id_to_string(Spec1bSm_StateId id);

// Thread safe.
char const * Spec1bSm_event_id_to_string(Spec1bSm_EventId id);

// Generated state machine
struct Spec1bSm
{
    // Used internally by state machine. Feel free to inspect, but don't modify.
    Spec1bSm_StateId state_id;
    
    // Used internally by state machine. Don't modify.
    Spec1bSm_Func ancestor_event_handler;
    
    // Used internally by state machine. Don't modify.
    Spec1bSm_Func current_event_handlers[Spec1bSm_EventIdCount];
    
    // Used internally by state machine. Don't modify.
    Spec1bSm_Func current_state_exit_handler;
    
    // Variables. Can be used for inputs, outputs, user variables...
    Spec1bSm_Vars vars;
};

