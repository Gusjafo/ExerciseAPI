using Aplication.DTOs;
using Domain.Entities;
using Domain.Enums;
using System.Collections.Generic;

namespace Aplication.Mappers
{
    public static class ExerciseMapper
    {
        //public static ExerciseDTO exerciseToDTO(Exercise exercise)
        //{
        //    return new ExerciseDTO
        //    {
        //        name = exercise.Name,
        //        type = exercise.ExerciseType.ToString(),
        //        muscle = exercise.Muscle.ToString(),
        //        equipment = exercise.Equipment,
        //        difficulty = exercise.Difficulty.ToString(),
        //        instructions = exercise.Instructions,
        //    };
        //}

        //public static Exercise DTOToExercise(ExerciseDTO exerciseDTO)
        //{
        //    return new Exercise
        //    {
        //        Name = exerciseDTO.name,
        //        ExerciseType = (ExerciseType)Enum.Parse(typeof(ExerciseType), exerciseDTO.type ?? "none"),
        //        Muscle = (Muscle)Enum.Parse(typeof(Muscle), exerciseDTO.muscle ?? "none"),
        //        Equipment = exerciseDTO.equipment,
        //        Difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), exerciseDTO.difficulty ?? "none"),
        //        Instructions = exerciseDTO.instructions
        //    };
        //}

        public static ExerciseJsonDTO JsonToDTO(ExerciseJsonModel exerciseJson)
        {
            return new ExerciseJsonDTO
            {
                Name = exerciseJson.Name,
                Aliases = exerciseJson.Aliases,
                Force = (Force)Enum.Parse(typeof(Force), exerciseJson?.Force ?? "none"),
                Mechanic = (Mechanic)Enum.Parse(typeof(Mechanic), exerciseJson?.Mechanic ?? "none"),
                Equipment = exerciseJson?.Equipment ?? null,
                Level = (Level)Enum.Parse(typeof(Level), exerciseJson?.Level ?? "none"),
                Category = exerciseJson?.Category ?? null,
                Instructions = exerciseJson?.Instructions ?? [""],
                PrimaryMuscles = exerciseJson?.PrimaryMuscles ?? [],
                SecondaryMuscles = exerciseJson?.SecondaryMuscles ?? [],
                Description = exerciseJson?.Description ?? null,
                Tips = exerciseJson?.Tips ?? null,
            };
        }

        public static ExerciseFullDTO ExerciseToDTO(Exercise exercise) 
        {

            return new ExerciseFullDTO
            {
                Id = exercise.Id ?? null,
                Name = exercise.Name ?? null,
                Aliases = exercise.Aliases?
                                  .Where(alias => !string.IsNullOrEmpty(alias.Alias))
                                  .Select(alias => alias.Alias)
                                  .ToList() ?? [],
                Force = exercise.Force.ToString() ?? null,
                Mechanic = exercise.Mechanic.ToString() ?? null,
                Equipment = exercise.Equipment ?? null,
                Level = exercise.Level.ToString() ?? null,
                Category = exercise.Category ?? null,
                Instructions = exercise.Instructions?
                                       .Where(instr => !string.IsNullOrEmpty(instr.Instruction))
                                       .Select(instr => instr.Instruction)
                                       .ToList() ?? [],
                PrimaryMuscles = exercise.PrimaryMuscles?
                                         .Where(prim => !string.IsNullOrEmpty(prim.PrimaryMuscle))
                                         .Select (prim => prim.PrimaryMuscle)
                                         .ToList () ?? [],
                SecondaryMuscles = exercise.SecondaryMuscles?
                                         .Where(secon => !string.IsNullOrEmpty(secon.SecondaryMuscle))
                                         .Select(secon => secon.SecondaryMuscle)
                                         .ToList() ?? [],
                Description = exercise.Description ?? null,
                Tips = exercise.Tips?
                               .Where(tip => !string.IsNullOrEmpty(tip.Tip))
                               .Select(tip => tip.Tip)
                               .ToList() ?? [],
                UrlVideo = exercise.UrlVideo ?? null,
                UrlPhoto = exercise.UrlPhoto ?? null,
                UrlGif = exercise.UrlGif ?? null
            };
        }
    }

}


