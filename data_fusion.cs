// Project: Implementation of Multi-Sensor Data Fusion for Forward Collision Warning
// Chair of of Communications Engineering
// Multisensorial Systems Laboratory
// Note: Source code is not shared due to institutional restrictions.
//       This file only contains architecture-level explanations.

// Important:
// Models implemented here are integrated into the BASELABS Create
// framework. See README for project scope and details.

// PART 1: State Transition Model (CV model)
// Explanation: Defines how object position and velocity evolve over time.

// PART 2: Radar Measurement Model
// Explanation: Converts object state (x, y, vx, vy) into radar observables
// (range, azimuth, radial velocity).

// PART 3: Radar Detection Model
// Explanation: Determines if an object lies within radar field of view
// (range + azimuth limits).

// PART 4: Radar Track Proposer
// Explanation: Creates new tracks from unmatched radar measurements by
// initializing state and covariance.

// PART 5: Camera Measurement Model
// Explanation: Projects 3D world coordinates onto the 2D image plane using
// the calibration matrix.

// PART 6: Camera Detection Model
// Explanation: Determines if an object lies within the camera field of view.

// PART 7: Camera Track Proposer
// Explanation: (optional) Creates new tracks from unmatched camera detections.

// *Fusion Workflow (in processing order)*

// PART 8: Usage in Predict0 - State Transition
// Explanation: The CV state transition model (PART 1) is invoked by the UKF to
// predict the next state before radar processing.

// PART 9: Usage in Predict0 - Radar Measurement
// Explanation: The Radar Measurement Model (PART 2) predicts expected radar
// measurements from the predicted state.

// PART 10: Usage in Update0 - Radar Detection
// Explanation: The Radar Detection Model (PART 3) applies FOV gating/detection
// probability during radar update and association.

// PART 11: Usage in ProposeNewTracks0 - Radar Track Proposal
// Explanation: The Radar Track Proposer (PART 4) initializes new tracks from
// unmatched radar measurements.

// PART 12: Usage in Predict1 - State Transition
// Explanation: The CV state transition model (PART 1) is invoked again by the
// UKF before camera processing.

// PART 13: Usage in Predict1 - Camera Measurement
// Explanation: The Camera Measurement Model (PART 5) predicts how the state
// maps to the image plane (row/column).

// PART 14: Usage in Update1 - Camera Detection
// Explanation: The Camera Detection Model (PART 6) applies FOV gating/detection
// probability during camera update and association.

// PART 15: Usage in ProposeNewTracks1 - Camera Track Proposal
// Explanation: The Camera Track Proposer (PART 7) initializes new tracks from
// unmatched camera measurements.

// Fusion Output: Time-to-Collision (TTC)
// Explanation: Once the radar and camera information are fused, the system has
// a reliable estimate of distance and relative speed to the leading vehicle.
// Using TTC = distance / relative speed, the time to potential collision is
// calculated. If this value drops below 20s, a forward collision warning is
// triggered.
