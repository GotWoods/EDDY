global using Xunit;

// Eddy.Edifact.Mapping.Cache.MapCache (a reflection cache internal to Eddy.Edifact, out of scope for this
// project) populates a plain Dictionary the first time each segment type is mapped, guarded by a lock that
// does not protect the dictionary's own read path. Two EDIFACT tests hitting a not-yet-cached segment type
// on different threads at the same time can therefore race on that dictionary. Running this assembly's
// tests without collection parallelization avoids that race without touching Eddy.Edifact.
[assembly: CollectionBehavior(DisableTestParallelization = true)]
